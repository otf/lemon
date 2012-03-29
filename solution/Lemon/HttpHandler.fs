namespace Lemon

open System.Linq
open System.Web
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting

open System.ComponentModel.Composition.Primitives
open Http

type Server = HttpRequest -> Response

type HttpHandler() =
  [<Import("aaa")>]
  let mutable server = Unchecked.defaultof<Server>
  interface  IHttpHandler with
    member x.IsReusable = true
    member x.ProcessRequest(ctx: HttpContext) = 
      server ctx.Request ctx.Response |> ignore


