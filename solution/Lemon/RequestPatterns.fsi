namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

[<AutoOpen>]
module RequestPatterns =

  val (|RawUrl|) : Request -> string

  val (|Url|) : Request -> string list

  val (|GET|_|) : Request -> Request option

  val (|POST|_|) : Request -> (Request * Stream) option

  val (|PUT|_|) : Request -> (Request * Stream) option

  val (|DELETE|_|) : Request -> Request option

  val (|QueryParams|) : Request -> Map<string, string>
  
  val (|Headers|) : Request -> Map<string, string>
