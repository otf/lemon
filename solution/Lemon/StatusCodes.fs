namespace Lemon

[<AutoOpen>]
module StatusCodes =
  let ok : Responser = setStatusCode 200
  let created : Responser  = setStatusCode 201
  let noContent : Responser  = setStatusCode 204
  let partialContent : Responser  = setStatusCode 206

  let found : Responser  = setStatusCode 302

  let badRequest : Responser  = setStatusCode 400
  let unauthorized : Responser  = setStatusCode 401
  let forbidden : Responser  = setStatusCode 403
  let notFound : Responser  = setStatusCode 404
  let methodNotAllowed : Responser  = setStatusCode 405
  let conflict : Responser  = setStatusCode 409
  let gone : Responser  = setStatusCode 410

  let internalServerError : Responser  = setStatusCode 500
  let notImplemented : Responser  = setStatusCode 501