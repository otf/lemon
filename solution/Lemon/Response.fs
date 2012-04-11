namespace Lemon

open System
open System.IO
open System.Web
open System.Xml.Linq
open Request

module Response =
  
  type Responser = HttpResponse -> HttpResponse

  let setStatusCode code (resp: HttpResponse) =
    resp.StatusCode <- code
    resp

  let ok = setStatusCode 200
  let noContent = setStatusCode 204
  let notFound = setStatusCode 404
  let methodNotAllowed = setStatusCode 405
  let internalServerError = setStatusCode 500

  let setHeader name value (resp:HttpResponse) =
    resp.AddHeader (name, value)
    resp

  let response (body:string) (resp: HttpResponse) = 
    resp.Write body
    resp

  let xmlResponse (body:XElement) = 
    body.ToString () |> response >> setHeader "Content-Type" "application/xml"
