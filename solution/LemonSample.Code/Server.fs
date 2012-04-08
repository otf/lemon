module Server

  open Lemon
  open Lemon.Request
  open Lemon.Response
  open System.Web
  open System.ComponentModel.Composition
  open System.Json
 
  [<Export>]
  let (server:Server) = function
      | GET(req) -> match req with
        | URL ["xml"; model; id] ->
          let modelXml = sprintf "<%s id=\"%s\"/>" model id
          response modelXml >> ok >> setHeader "Content-Type" "text/xml"

        | URL ["json"; model; id] ->
          let modelJson = sprintf "{\"name\":\"%s\", \"id\":\"%s\" }" model id |> JsonValue.Parse
          jsonResponse modelJson >> ok >> setHeader "Content-Type" "text/json"

        | _ -> ok

      | POST (req, body) & Headers (headers) 
        when List.exists ((=) ("Content-Type", "text/xml")) headers
          -> readXml body |> xmlResponse
      | _ -> methodNotAllowed

