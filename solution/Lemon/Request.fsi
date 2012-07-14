namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

module Request =

  val (|Has|_|) : string -> (string * string) list -> string option

  val (|Last|_|) : string list -> string option

  val (|RawUrl|) : HttpRequest -> string

  val (|Url|) : HttpRequest -> string list

  val (|GET|_|) : HttpRequest -> HttpRequest option

  val (|POST|_|) : HttpRequest -> (HttpRequest * Stream) option

  val (|PUT|_|) : HttpRequest -> (HttpRequest * Stream) option

  val (|DELETE|_|) : HttpRequest -> HttpRequest option

  val (|Params|) : HttpRequest -> (string * string) list
  
  val (|Headers|) : HttpRequest -> (string * string) list
 
  val existHeader : string -> (string * string) list -> bool

  val readText : Stream -> string

  val readXml : Stream -> XElement

  val readParameters : Stream -> (string * string) list