module BodyTest


open NaturalSpec
open System
open System.IO
open System.Web
open System.Xml.Linq
open System.Collections.Specialized
open Lemon

[<Scenario>]
let ``Read a text`` () =
  use stream = new MemoryStream ()
  use writer = new StreamWriter (stream)

  writer.Write("piyopiyo")
  writer.Flush ()
  stream.Seek(0L, SeekOrigin.Begin) |> ignore

  Given stream
    |> When readText
    |> It should equal "piyopiyo"
    |> Verify

[<Scenario>]
let ``Read a XML`` () =
  use stream = new MemoryStream ()
  use writer = new StreamWriter (stream)

  writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><person>otf</person>")
  writer.Flush ()
  stream.Seek(0L, SeekOrigin.Begin) |> ignore

  Given stream
    |> When readXml
    |> It have (fun right -> XElement.DeepEquals (XElement.Parse("<person>otf</person>") ,right))
    |> Verify

[<Scenario>]
let ``Read a Forms`` () =
  use stream = new MemoryStream ()
  use writer = new StreamWriter (stream)

  writer.Write("Id=10&Name=otf")
  writer.Flush ()
  stream.Seek(0L, SeekOrigin.Begin) |> ignore

  Given stream
    |> When readForms
    |> It should equal [("Id","10"); ("Name","otf")]
    |> Verify
