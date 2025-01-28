using Dotnet.Modular.Core;
using Dotnet.Modular.Core.Extensions.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Dotnet.Modular.Core.Extensions.Common;
using Dotnet.Modular.Core.States;

namespace Dotnet.Modular.Modules.Navigation;

[Export(ExportType.Trancient, typeof(IMenuManager))]
public class MenuManager : IMenuManager
{
    protected NavigationOptions Options { get; }
    protected IServiceScopeFactory ServiceScopeFactory { get; }
    protected ISimpleStateCheckerManager<IApplicationMenuItem> SimpleStateCheckerManager { get; }

    public MenuManager(
        IOptions<NavigationOptions> options,
        IServiceScopeFactory serviceScopeFactory
        //ISimpleStateCheckerManager<IApplicationMenuItem> simpleStateCheckerManager
        )
    {
        Options = options.Value;
        ServiceScopeFactory = serviceScopeFactory;
       // SimpleStateCheckerManager = simpleStateCheckerManager;
    }


    public Task<IApplicationMenu> GetAsync(string name)
    {
        return GetInternalAsync(name);
    }

    public Task<IApplicationMenu> GetMainMenuAsync()
    {
        return GetAsync(Options.MainMenuNames.ToArray());
    }

    protected virtual async Task<IApplicationMenu> GetAsync(params string[] menuNames)
    {
        if (menuNames.IsNullOrEmpty())
        {
            return new ApplicationMenu(StandardMenus.Main);
        }

        var menus = new List<IApplicationMenu>();

        foreach (var menuName in Options.MainMenuNames)
        {
            menus.Add(await GetInternalAsync(menuName));
        }

        return MergeMenus(menus);
    }

    protected virtual IApplicationMenu MergeMenus(List<IApplicationMenu> menus)
    {
        if (menus.Count == 1)
        {
            return menus[0];
        }

        var firstMenu = menus[0];

        for (int i = 1; i < menus.Count; i++)
        {
            var currentMenu = menus[i];
            foreach (var menuItem in currentMenu.Items)
            {
                firstMenu.AddItem(menuItem);
            }
        }

        return firstMenu;
    }

    protected virtual async Task<IApplicationMenu> GetInternalAsync(string name)
    {
        var menu = new ApplicationMenu(name);

        using (var scope = ServiceScopeFactory.CreateScope())
        {
            //using (RequirePermissionsSimpleBatchStateChecker<IApplicationMenuItem>.Use(new RequirePermissionsSimpleBatchStateChecker<ApplicationMenuItem>()))
            //{
            var context = new MenuConfigurationContext(menu, scope.ServiceProvider);

            foreach (var contributor in Options.MenuProviders)
            {
                await contributor.ConfigureMenuAsync(context);
            }

            await CheckPermissionsAsync(scope.ServiceProvider, menu);
            //}
        }

        NormalizeMenu(menu);
       // NormalizeMenuGroup(menu);

        return menu;
    }

    protected virtual async Task CheckPermissionsAsync(IServiceProvider serviceProvider, IHasMenuItems menuWithItems)
    {
        var allMenuItems = new List<IApplicationMenuItem>();
        GetAllMenuItems(menuWithItems, allMenuItems);

        foreach (var item in allMenuItems)
        {
            //if (!item.RequiredPermissionName.IsNullOrWhiteSpace())
            //{
            //    item.RequirePermissions(item.RequiredPermissionName!);
            //}
        }

        var checkPermissionsMenuItems = allMenuItems.Where(x => x.StateCheckers.Any()).ToArray();

        if (checkPermissionsMenuItems.Any())
        {
            var toBeDeleted = new HashSet<IApplicationMenuItem>();
            var result = await SimpleStateCheckerManager.IsEnabledAsync(checkPermissionsMenuItems);
            foreach (var menu in checkPermissionsMenuItems)
            {
                if (!result[menu])
                {
                    toBeDeleted.Add(menu);
                }
            }

            RemoveMenus(menuWithItems, toBeDeleted);
        }
    }

    protected virtual void GetAllMenuItems(IHasMenuItems menuWithItems, List<IApplicationMenuItem> output)
    {
        foreach (var item in menuWithItems.Items)
        {
            output.Add(item);
            GetAllMenuItems(item, output);
        }
    }

    protected virtual void RemoveMenus(IHasMenuItems menuWithItems, HashSet<IApplicationMenuItem> toBeDeleted)
    {
        menuWithItems.Items.RemoveAll(toBeDeleted.Contains);

        foreach (var item in menuWithItems.Items)
        {
            RemoveMenus(item, toBeDeleted);
        }
    }

    protected virtual void NormalizeMenu(IHasMenuItems menuWithItems)
    {
        foreach (var item in menuWithItems.Items)
        {
            NormalizeMenu(item);
        }

        menuWithItems.Items.Normalize();
    }

    //protected virtual void NormalizeMenuGroup(ApplicationMenu applicationMenu)
    //{
    //    foreach (var menuGroup in applicationMenu.Items.Where(x => !x.GroupName.IsNullOrWhiteSpace()).GroupBy(x => x.GroupName))
    //    {
    //        var group = applicationMenu.GetMenuGroupOrNull(menuGroup.First().GroupName!);
    //        if (group != null)
    //        {
    //            continue;
    //        }

    //        foreach (var menuItem in menuGroup)
    //        {
    //            menuItem.GroupName = null;
    //        }
    //    }

    //    applicationMenu.Groups.Normalize();
    //}
}
