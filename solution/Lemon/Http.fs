namespace Lemon

module Http =
  open System
  open System.IO
  open System.Web
  open System.Xml.Linq
  open System.ComponentModel.Composition

  
  type Server = HttpRequest -> HttpResponse -> HttpResponse

  let readHeaders (rawHeaders: System.Collections.Specialized.NameValueCollection)  =
    [ for key in rawHeaders.Keys -> (key , rawHeaders.[key])]

  let existHeader name = List.exists (fun kvp -> fst kvp = name)

  let readText (st:Stream) = use reader = new StreamReader (st) in reader.ReadToEnd ()
  let readXml  (st:Stream) = readText st |> XElement.Parse

  let (|URL|_|) (url:string) =
    let pathes = url.Split ([| "/" |], StringSplitOptions.RemoveEmptyEntries)
    Some <| List.ofArray pathes

  let (|GET|_|) (req:HttpRequest) =
    if req.HttpMethod = "GET" then
      Some (req.RawUrl, readHeaders req.Headers)
    else
      None

  let (|POST|_|) (req:HttpRequest) =
    if req.HttpMethod = "POST" then
      Some (req.RawUrl, readHeaders req.Headers, req.InputStream)
    else
      None
    
  type Response = HttpResponse -> HttpResponse

  let response (body:string) (resp: HttpResponse) = 
    resp.Write body
    resp
    
  let xmlResponse (body:XElement) = body.ToString () |> response

  let setStatusCode code (resp: HttpResponse) =
    resp.StatusCode <- code
    resp

  let setHeader name value (resp:HttpResponse) =
    resp.AddHeader (name, value)
    resp

  let ok = setStatusCode 200
  let noContent = setStatusCode 204