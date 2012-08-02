namespace Lemon

module Body =
  open System
  open System.IO
  open System.Web
  open System.Xml.Linq
  
  let readText (st:Stream) = let reader = new StreamReader (st) in reader.ReadToEnd ()

  let readXml (st:Stream) = readText st |> XElement.Parse

  let readForms (st:Stream) = readText st |> HttpUtility.ParseQueryString |> nameValueCollections2List
