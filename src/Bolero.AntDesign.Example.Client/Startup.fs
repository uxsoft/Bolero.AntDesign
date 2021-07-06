namespace Bolero.AntDesign.Example.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Bolero.Remoting.Client
open Microsoft.Extensions.DependencyInjection

module Program =

    [<EntryPoint>]
    let Main args =
        let builder = WebAssemblyHostBuilder.CreateDefault(args)
        builder.RootComponents.Add<Main.MyApp>("#main")
        builder.Services.AddRemoting(builder.HostEnvironment) |> ignore
        builder.Services.AddAntDesign() |> ignore
        builder.Build().RunAsync() |> ignore
        0
