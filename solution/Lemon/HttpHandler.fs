namespace Lemon

open System.Linq
open System.Web
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting
open Http

type HttpHandler() =

  let importServer path =
    use dirCatalog = new DirectoryCatalog (path)
    use con = new CompositionContainer (dirCatalog) 
    con.GetExportedValues<Server>() |> Seq.nth 0

  interface  IHttpHandler with
    member x.IsReusable = true
    member x.ProcessRequest(ctx: HttpContext) = 
      let server = importServer <| ctx.Server.MapPath("bin")
      server ctx.Request ctx.Response |> ignore


