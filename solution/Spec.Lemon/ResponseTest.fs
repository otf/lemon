module ResponseTest

open NaturalSpec
open Rhino.Mocks

open System
open System.IO
open System.Web
open System.Collections.Specialized
open Lemon

[<Example(200)>]
[<Example(201)>]
[<Example(204)>]
[<Example(404)>]
[<Example(405)>]
[<Example(500)>]
let ``Set statas code by Int`` (statusCode) =
  let res = MockRepository.GenerateMock<Response> ()

  Given res
    |> When (setStatusCode statusCode)
    |> It have (fun res -> res.StatusCode = statusCode)
    |> Verify


[<Example("Content-Type", "application/json")>]
[<Example("Content-Length", "1000")>]
let ``Set header`` (kvp) =
  let res = MockRepository.GenerateMock<Response> ()

  let col = NameValueCollection ()
  
  RhinoMocksExtensions.Expect<Response, NameValueCollection>(res, fun x -> x.Headers).Return(col)
    |> ignore

  Given res
    |> When (setHeader (fst kvp) (snd kvp))
    |> It have (fun _ -> col.[fst kvp] = (snd kvp))
    |> Verify


//[<Example("")>]
//[<Example("<person>otf</person>")>]
//let ``Set response by text`` (text) =
//  let res = MockRepository.GenerateMock<Response> ()
//
//  use ms = new MemoryStream ()
//  use writer = new StreamWriter (ms)
//  
//  RhinoMocksExtensions.Expect<Response, string -> unit>(res, fun res -> writer.write)
//    |> ignore
//
//  let readAll (res:Response) = 
//    res.Write( "aaaa")
//    res.OutputStream.Seek (0L, SeekOrigin.Begin) |> ignore
//    use reader = new StreamReader (res.OutputStream)
//    reader.ReadToEnd ()
//
//  Given res
//    |> When (response text)
//    |> When readAll
//    |> It should equal text
//    |> Verify