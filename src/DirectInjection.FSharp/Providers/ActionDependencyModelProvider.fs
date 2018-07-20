namespace Providers

open Microsoft.AspNetCore.Mvc.ApplicationModels
open Microsoft.AspNetCore.Mvc.ModelBinding

type ActionDependencyModelProvider() =
    interface IApplicationModelProvider with
        member __.Order = -901
        member __.OnProvidersExecuted _ = ()

        member __.OnProvidersExecuting (context: ApplicationModelProviderContext) =
            context.Result.Controllers
            |> Seq.collect (fun x -> x.Actions)
            |> Seq.collect (fun x -> x.Parameters)
            |> Seq.filter (fun x -> x.ParameterType.Name.EndsWith("Service"))
            |> Seq.iter (fun x -> x.BindingInfo <- BindingInfo(BindingSource = BindingSource.Services))