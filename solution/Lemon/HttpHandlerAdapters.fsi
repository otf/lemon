namespace Lemon

open System
open System.Web
open Lemon

module HttpHandlerAdapters =
  val httpHandler : #IHttpHandler -> Responser
  val httpHandlerFactory : #IHttpHandlerFactory -> Responser
  val staticFile : Responser
  val pageFile : Responser