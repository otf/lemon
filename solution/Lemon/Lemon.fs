namespace Lemon

  open System.Web

  type Request = HttpRequestBase
  type Response = HttpResponseBase
  type Responser = HttpResponseBase -> HttpResponseBase
  type Server = Request -> Responser