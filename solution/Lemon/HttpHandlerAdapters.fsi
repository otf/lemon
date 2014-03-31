namespace Lemon

open System
open System.Web
open Lemon

module HttpHandlerAdapters =
  val adapt : #IHttpHandler -> Responser
  val staticFile : Responser