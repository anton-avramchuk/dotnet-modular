using Dotnet.Modular.Core.Extensions.Common;

namespace Dotnet.Modular.Modules.Navigation;

public class ApplicationMenuItemList : List<IApplicationMenuItem>
{
    public ApplicationMenuItemList()
    {

    }

    public ApplicationMenuItemList(int capacity)
        : base(capacity)
    {

    }

    public ApplicationMenuItemList(IEnumerable<IApplicationMenuItem> collection)
        : base(collection)
    {

    }

    public void Normalize()
    {
        RemoveEmptyItems();
        Order();
    }

    private void RemoveEmptyItems()
    {
        RemoveAll(item => item.IsLeaf && item.Url.IsNullOrEmpty());
    }

    private void Order()
    {
        //TODO: Is there any way that is more performant?
        var orderedItems = this.OrderBy(item => item.Order).ToArray();
        Clear();
        AddRange(orderedItems);
    }
}
