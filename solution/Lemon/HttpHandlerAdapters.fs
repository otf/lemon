namespace Lemon

open System
open System.Web
open Lemon
  
module HttpHandlerAdapters =
  let httpHandler (handler : #IHttpHandler) (_:Response) = 
    handler.ProcessRequest(HttpContext.Current)
    HttpResponseWrapper(HttpContext.Current.Response) :> Response

  let staticFile resp = 
    let handlerType = (typeof<HttpApplication>).Assembly.GetType("System.Web.StaticFileHandler", true) 
    let handler = Activator.CreateInstance(handlerType, true) :?> IHttpHandler
    httpHandler handler resp