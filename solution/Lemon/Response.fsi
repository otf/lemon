namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

module Response =

  type Responser = HttpResponse -> HttpResponse

  val ok : Responser
  val noContent : Responser
  val notFound : Responser
  val methodNotAllowd : Responser
  val internalServerError : Responser
  val response : string -> Responser
  val xmlResponse : XElement -> Responser
  val setStatusCode : int -> Responser
  val setHeader : string -> string -> Responser

