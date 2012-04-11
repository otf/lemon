namespace LemonSample

open Server
  
  type Handler () =
    inherit Lemon.HttpHandler(server)
