// Learn more about F# at http://fsharp.net

module Server
  open Lemon.Http
  open Lemon.Response
  open System.Web
  open System.ComponentModel.Composition
 
  [<Export>]
  let (server:Server) = function
      | GET (URL ["products"; id]) -> 
          let product = "<product id=\"" + id + "\"/>"
          response product >> ok >> setHeader "content-type" "text/plain"
      | POST (req, body) & URL ([]) -> readXml body |> xmlResponse
      | _ -> ok

