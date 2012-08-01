namespace Lemon

  open System.Web

  type Server = HttpRequestBase -> HttpResponseBase -> HttpResponseBase
