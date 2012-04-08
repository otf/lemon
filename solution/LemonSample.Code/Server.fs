module Server

  open Lemon
  open Lemon.Request
  open Lemon.Response
  open System.Web
  open System.ComponentModel.Composition
 
  [<Export>]
  let (server:Server) = function
      | GET(req) -> match req with
        | URL [model; id] ->
          let modelXml = sprintf "<%s id=\"%s\"/>" model id
          response modelXml >> ok >> setHeader "Content-Type" "text/xml"
        | _ -> ok

      | POST (req, body) & Headers (headers) 
        when List.exists ((=) ("Content-Type", "text/xml")) headers
          -> readXml body |> xmlResponse
      | _ -> methodNotAllowed

