// Learn more about F# at http://fsharp.net

module Server
  open Lemon.Http
  open System.Web
  open System.ComponentModel.Composition
 
  [<Export>]
  let (server:Server) = function
      | GET (url , headers) -> response "12" >> ok >> setHeader "content-type" "text/plain"
      | POST (url, headers, body) -> readXml body |> xmlResponse
      | _ -> ok

