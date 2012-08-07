module Server

  open Lemon
  open System
  open System.IO
  open System.Json
  
  let readJson (st:Stream) = readText st |> JsonValue.Parse

  let jsonResponse (body:JsonValue) = 
    body.ToString () |> response >> setHeader "Content-Type" "application/json"
 
  let (server:Server) = function
      | GET(Url ["xml"; model; id]) -> 
          let modelXml = sprintf "<%s id=\"%s\"/>" model id
          response modelXml >> ok

      | GET(Url ["json"; model; id]) ->
          let modelJson = sprintf "{\"name\":\"%s\", \"id\":\"%s\" }" model id |> JsonValue.Parse
          jsonResponse modelJson >> ok

      | POST (req, body) & Headers (Has "Content-Type" "application/xml") -> readXml body |> xmlResponse

      | GET(Url ["error"]) -> raise(Exception("エラーです"))

      | _ -> methodNotAllowed
