namespace Lemon

open Http

module Response =

  let ok = setStatusCode 200
  let noContent = setStatusCode 204
  let notFound = setStatusCode 404
  let methodNotAllowd = setStatusCode 405
  let internalServerError = setStatusCode 500