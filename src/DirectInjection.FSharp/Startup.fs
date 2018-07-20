namespace DirectInjection.FSharp

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.DependencyInjection.Extensions
open Microsoft.AspNetCore.Mvc.ApplicationModels
open Providers
open DirectInjection.FSharp.Services

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member __.ConfigureServices(services: IServiceCollection) =
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1) |> ignore

        let descriptor = ServiceDescriptor.Transient<IApplicationModelProvider, ActionDependencyModelProvider>()
        services.TryAddEnumerable(descriptor) |> ignore
        services.AddSingleton<MyService>(MyService()) |> ignore

    member __.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseHsts() |> ignore

        // app.UseHttpsRedirection() |> ignore
        app.UseMvc() |> ignore

    member val Configuration : IConfiguration = null with get, set