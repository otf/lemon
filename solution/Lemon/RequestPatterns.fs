namespace Lemon

module RequestPatterns =
  open System
  open System.IO
  open System.Web
  open System.Xml.Linq
  
  let (|RawUrl|) (req:Request) = req.RawUrl

  let (|Url|) (req:Request) =
    let pathes = req.Url.LocalPath.Split ([| "/" |], StringSplitOptions.RemoveEmptyEntries)
    List.ofArray pathes

  let (|QueryParams|) (req:Request) =
    req.QueryString |> nameValueCollections2List
  
  let (|Headers|) (req:Request) =
    req.Headers |> nameValueCollections2List

  let (|GET|_|) (req:Request) =
    if req.HttpMethod = "GET" then
      Some req
    else
      None

  let (|POST|_|) (req:Request) =
    if req.HttpMethod = "POST" then
      Some (req, req.InputStream)
    else
      None

  let (|PUT|_|) (req:Request) =
    if req.HttpMethod = "PUT" then
      Some (req, req.InputStream)
    else
      None

  let (|DELETE|_|) (req:Request) =
    if req.HttpMethod = "DELETE" then
      Some req
    else
      None
    