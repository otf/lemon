namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq
open System.Json

module Response =

  type Responser = HttpResponse -> HttpResponse

  val ok : Responser
  val noContent : Responser
  val notFound : Responser
  val methodNotAllowed : Responser
  val internalServerError : Responser
  val response : string -> Responser
  val xmlResponse : XElement -> Responser
  val jsonResponse : JsonValue -> Responser
  val setStatusCode : int -> Responser
  val setHeader : string -> string -> Responser

