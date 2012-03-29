namespace FunctionalWeb.Framework

open System.Web;

type HttpHandler() = 
     interface IHttpHandler with
        member this.ProcessRequest(context:HttpContext) = 
                context.Response.Write("Hello from a simple F# Http Handler!")
                context.Response.End()
        member this.IsReusable with get() = true