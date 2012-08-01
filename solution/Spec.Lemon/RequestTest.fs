module RequestTest


open NaturalSpec
open Rhino.Mocks

open System
open System.Web
open System.Collections.Specialized
open Lemon

[<Scenario>]
let ``Match a RawUrl`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, string>(req, fun x -> x.RawUrl).Return("http://www.example.com")
    |> ignore

  Given req
    |> When (function
              | RawUrl "http://www.example.com" -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a Url`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, Uri>(req, fun x -> x.Url).Return(Uri ("http://www.example.com/Products/100"))
    |> ignore

  Given req
    |> When (function
              | Url ["Products"; "100"] -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a GET Method`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, string>(req, fun x -> x.HttpMethod).Return("GET")
    |> ignore

  Given req
    |> When (function
              | GET _ -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a POST Method`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, string>(req, fun x -> x.HttpMethod).Return("POST")
    |> ignore

  Given req
    |> When (function
              | POST _ -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a PUT Method`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, string>(req, fun x -> x.HttpMethod).Return("PUT")
    |> ignore

  Given req
    |> When (function
              | PUT _ -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a DELETE Method`` () =
  let req = MockRepository.GenerateMock<Request> ()
  RhinoMocksExtensions.Expect<Request, string>(req, fun x -> x.HttpMethod).Return("DELETE")
    |> ignore

  Given req
    |> When (function
              | DELETE _ -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Match a QueryParameter`` () =
  let req = MockRepository.GenerateMock<Request> ()

  let col = NameValueCollection ()
  col.Add ("Id", "10")
  col.Add ("Name", "otf")
  RhinoMocksExtensions.Expect<Request, NameValueCollection>(req, fun x -> x.QueryString).Return(col)
    |> ignore

  Given req
    |> When (function
              | QueryParams (Has "Id" "10") & QueryParams (Has "Name" "otf") -> true
              | _ -> false)
    |> It should equal true
    |> Verify

[<Scenario>]
let ``Does not match a QueryParameter`` () =
  let req = MockRepository.GenerateMock<Request> ()

  let col = NameValueCollection ()
  col.Add ("Id", "10")
  col.Add ("Name", "otf")
  RhinoMocksExtensions.Expect<Request, NameValueCollection>(req, fun x -> x.QueryString).Return(col)
    |> ignore

  Given req
    |> When (function
              | QueryParams (Has "Id" "5") -> true
              | _ -> false)
    |> It should equal false
    |> Verify


[<Scenario>]
let ``Match a Headers`` () =
  let req = MockRepository.GenerateMock<Request> ()

  let col = NameValueCollection ()
  col.Add ("Content-Type", "application/json")
  col.Add ("Content-Length", "1000")
  RhinoMocksExtensions.Expect<Request, NameValueCollection>(req, fun x -> x.Headers).Return(col)
    |> ignore

  Given req
    |> When (function
              | Headers (Has "Content-Type" "application/json") & Headers (Has "Content-Length" "1000") -> true
              | _ -> false)
    |> It should equal true
    |> Verify