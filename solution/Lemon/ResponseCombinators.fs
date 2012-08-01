namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq

module ResponseModule =
  
  let setStatusCode code (resp: Response) =
    resp.StatusCode <- code
    resp

  let ok = setStatusCode 200
  let noContent = setStatusCode 204
  let notFound = setStatusCode 404
  let methodNotAllowed = setStatusCode 405
  let internalServerError = setStatusCode 500

  let setHeader name value (resp:Response) =
    resp.AddHeader (name, value)
    resp

  let response (body:string) (resp: Response) = 
    resp.Write body
    resp

  let xmlResponse (body:XElement) = 
    body.ToString () |> response >> setHeader "Content-Type" "application/xml"
