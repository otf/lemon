namespace Lemon

open System
open System.Web
open Lemon

module ErrorHandler =
  val trySkipIisCustomErrors : Responser

  val errorHandler : (exn -> Responser) -> Server -> Server