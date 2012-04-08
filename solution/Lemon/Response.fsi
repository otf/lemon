namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq
open Http

module Response =

  val ok : Response
  val noContent : Response
  val notFound : Response
  val methodNotAllowd : Response
  val internalServerError : Response
