namespace DirectInjection.FSharp.Controllers
open Microsoft.AspNetCore.Mvc
open DirectInjection.FSharp.Services

type Request = {
    Hello: string
}

[<Route("api/[controller]/[action]")>]
type HelloController() =
    inherit ControllerBase()

    [<HttpGet>]
    member __.HelloGet(name: string, service: MyService) =
        printfn "%A" name
        service.SayHello()

    [<HttpPost>]
    member __.HelloPost([<FromBody>]request: Request, service: MyService) =
        printfn "%A" request.Hello
        service.SayHello()