namespace Lemon

open System
open System.Web
open Lemon

module ErrorHandler =
  val trySkipIisCustomErrors : Responser

  val errorHandler : Server -> (exn -> Responser) -> Request -> Responser