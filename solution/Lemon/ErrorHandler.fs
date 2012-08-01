namespace Lemon

open System
open System.Web

module ErrorHandler =

  let trySkipIisCustomErrors (resp:Response) = 
    resp.TrySkipIisCustomErrors <- true
    resp

  let errorHandler (handler:exn->Responser) (server:Server) (req:Request) = 
    try
      server req
    with ex ->
      handler ex