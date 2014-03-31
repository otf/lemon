namespace Lemon

open System
open System.Web
open Lemon

module HttpHandlerAdapters =
  val httpHandler : #IHttpHandler -> Responser
  val staticFile : Responser