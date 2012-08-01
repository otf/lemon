namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq
open Request

module Response =
  
  type Responser = HttpResponseBase -> HttpResponseBase

  let setStatusCode code (resp: HttpResponseBase) =
    resp.StatusCode <- code
    resp

  let ok = setStatusCode 200
  let noContent = setStatusCode 204
  let notFound = setStatusCode 404
  let methodNotAllowed = setStatusCode 405
  let internalServerError = setStatusCode 500

  let setHeader name value (resp:HttpResponseBase) =
    resp.AddHeader (name, value)
    resp

  let response (body:string) (resp: HttpResponseBase) = 
    resp.Write body
    resp

  let xmlResponse (body:XElement) = 
    body.ToString () |> response >> setHeader "Content-Type" "application/xml"
