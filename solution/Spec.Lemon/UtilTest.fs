module RequestTest

open NaturalSpec

open Lemon

let hasTwo kvp = 
  match kvp with
  | Has "two" "ni" -> true
  | _ -> false

let lastIsThree kvp = 
  match kvp with
  | Last "three" -> true
  | _ -> false

[<Scenario>]
let ``list has a element``() =
  Given [("one","ichi"); ("two","ni"); ("three","sann")]
    |> When hasTwo
    |> It should equal true
    |> Verify

[<Scenario>]
let ``last element is three``() =
  Given ["one"; "two"; "three"]
    |> When lastIsThree
    |> It should equal true
    |> Verify
