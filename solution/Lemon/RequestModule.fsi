namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

[<AutoOpen>]
module RequestModule =

  val (|Has|_|) : string -> (string * string) list -> string option

  val (|Last|_|) : string list -> string option

  val (|RawUrl|) : Request -> string

  val (|Url|) : Request -> string list

  val (|GET|_|) : Request -> Request option

  val (|POST|_|) : Request -> (Request * Stream) option

  val (|PUT|_|) : Request -> (Request * Stream) option

  val (|DELETE|_|) : Request -> Request option

  val (|Params|) : Request -> (string * string) list
  
  val (|Headers|) : Request -> (string * string) list
 
  val existHeader : string -> (string * string) list -> bool

  val readText : Stream -> string

  val readXml : Stream -> XElement

  val readParameters : Stream -> (string * string) list