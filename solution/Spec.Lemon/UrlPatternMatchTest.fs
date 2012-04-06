module Spec.Lemon.NaturalSpecSample

open NaturalSpec
open Lemon.Http

let isProduct100 (url:string) = 
  match url with
    | URL ["products"; "100"] -> true
    | _ -> false


[<Scenario>]
let ``URL PatternMatch`` () = 
  Given ("/products/100")
    |> When isProduct100     
    |> It should equal true
    |> Verify