namespace Lemon

open System
open System.Web

module ErrorHandler =

  let trySkipIisCustomErrors (resp:Response) = 
    resp.TrySkipIisCustomErrors <- true
    resp

  let errorHandler (server:Server) (handler:exn->Responser) (req:Request) = 
    try
      server req
    with ex ->
      handler ex