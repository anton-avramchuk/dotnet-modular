﻿using Dotnet.Modular.Core;

namespace Dotnet.Modular.AspNetCore.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder InitializeApplication(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));
        app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value = app;
        app.ApplicationServices.GetRequiredService<ObjectAccessor<IEndpointRouteBuilder>>().Value = app as IEndpointRouteBuilder;
        var application = app.ApplicationServices.GetRequiredService<ICrmApplicationWithExternalServiceProvider>();
        var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

        applicationLifetime.ApplicationStopping.Register(() =>
        {
            application.Shutdown();
        });

        applicationLifetime.ApplicationStopped.Register(() =>
        {
            application.Dispose();
        });

        application.Initialize(app.ApplicationServices);

        return app;
    }

}