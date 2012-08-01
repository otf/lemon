namespace Lemon

[<AutoOpen>]
module Util =
  let nameValueCollections2List (rawHeaders: System.Collections.Specialized.NameValueCollection)  =
    [ for key in rawHeaders.Keys -> (key , rawHeaders.[key])]

  let (|Has|_|) key (kvp : (string * string) list) =
    let kvp = dict kvp
    if kvp.ContainsKey key then
      kvp.[key] |> Some
    else
      None

  let (|Last|_|) (pathes:string list) =
   if not <| List.isEmpty pathes then
     List.rev pathes |> List.head |> Some
   else
     None