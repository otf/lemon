namespace LemonSample

open Server
open Lemon
open Lemon.ErrorHandler
  
type Handler () =
  inherit Lemon.HttpHandler(server |> errorHandler (fun ex -> response ex.Message >> trySkipIisCustomErrors))
