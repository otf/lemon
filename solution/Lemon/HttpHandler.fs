namespace Lemon

open System.Linq
open System.Web
open Request
open Response

type HttpHandler(server : Server) =

  interface  IHttpHandler with
    member x.IsReusable = true
    member x.ProcessRequest(ctx: HttpContext) = 
      let wrapper = HttpContextWrapper ctx
      server wrapper.Request wrapper.Response |> ignore


