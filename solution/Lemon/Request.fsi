namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

module Request =

  val (|Has|_|) : string -> (string * string) list -> string option

  val (|Last|_|) : string list -> string option

  val (|RawUrl|) : HttpRequestBase -> string

  val (|Url|) : HttpRequestBase -> string list

  val (|GET|_|) : HttpRequestBase -> HttpRequestBase option

  val (|POST|_|) : HttpRequestBase -> (HttpRequestBase * Stream) option

  val (|PUT|_|) : HttpRequestBase -> (HttpRequestBase * Stream) option

  val (|DELETE|_|) : HttpRequestBase -> HttpRequestBase option

  val (|Params|) : HttpRequestBase -> (string * string) list
  
  val (|Headers|) : HttpRequestBase -> (string * string) list
 
  val existHeader : string -> (string * string) list -> bool

  val readText : Stream -> string

  val readXml : Stream -> XElement

  val readParameters : Stream -> (string * string) list