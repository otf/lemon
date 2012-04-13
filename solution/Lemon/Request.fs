namespace Lemon

module Request =
  open System
  open System.IO
  open System.Web
  open System.Xml.Linq
  
  type Server = HttpRequest -> HttpResponse -> HttpResponse

  let nameValueCollections2List (rawHeaders: System.Collections.Specialized.NameValueCollection)  =
    [ for key in rawHeaders.Keys -> (key , rawHeaders.[key])]

  let existHeader (name:string) (headers:(string * string) list) = List.exists (fun kvp -> fst kvp = name) headers

  let readText (st:Stream) = use reader = new StreamReader (st) in reader.ReadToEnd ()

  let readXml  (st:Stream) = readText st |> XElement.Parse

  let (|URL|_|) (req:HttpRequest) =
    let pathes = req.Url.LocalPath.Split ([| "/" |], StringSplitOptions.RemoveEmptyEntries)
    Some <| List.ofArray pathes

  let (|Params|) (req:HttpRequest) =
    req.Params |> nameValueCollections2List

  let (|Headers|) (req:HttpRequest) =
    req.Headers |> nameValueCollections2List

  let (|GET|_|) (req:HttpRequest) =
    if req.HttpMethod = "GET" then
      Some req
    else
      None

  let (|POST|_|) (req:HttpRequest) =
    if req.HttpMethod = "POST" then
      Some (req, req.InputStream)
    else
      None

  let (|PUT|_|) (req:HttpRequest) =
    if req.HttpMethod = "PUT" then
      Some (req, req.InputStream)
    else
      None

  let (|DELETE|_|) (req:HttpRequest) =
    if req.HttpMethod = "DELETE" then
      Some req
    else
      None
    