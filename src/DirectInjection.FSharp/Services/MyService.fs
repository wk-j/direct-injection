namespace DirectInjection.FSharp.Services

type MyService() =
    member __.SayHello() = printfn "Hello, world!"
