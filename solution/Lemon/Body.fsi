namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

[<AutoOpen>]
module Body =
  val readText : Stream -> string

  val readXml : Stream -> XElement

  val readForms : Stream -> (string * string) list