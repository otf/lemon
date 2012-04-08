namespace Lemon

  open System.Web

  type Server = HttpRequest -> HttpResponse -> HttpResponse
