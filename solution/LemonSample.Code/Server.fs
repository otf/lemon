module Server

  open Lemon
  open Lemon.Request
  open Lemon.Response
  open System.IO
  open System.Json
  
  let readJson (st:Stream) = readText st |> JsonValue.Parse

  let jsonResponse (body:JsonValue) = 
    body.ToString () |> response >> setHeader "Content-Type" "application/json"
 
  let (server:Server) = function
      | GET(req) -> 
        match req with
          | URL ["xml"; model; id] ->
            let modelXml = sprintf "<%s id=\"%s\"/>" model id
            response modelXml >> ok

          | URL ["json"; model; id] ->
            let modelJson = sprintf "{\"name\":\"%s\", \"id\":\"%s\" }" model id |> JsonValue.Parse
            jsonResponse modelJson >> ok

          | _ -> ok

      | POST (req, body) & Headers (headers) 
        when List.exists ((=) ("Content-Type", "application/xml")) headers
          -> readXml body |> xmlResponse

      | _ -> methodNotAllowed
