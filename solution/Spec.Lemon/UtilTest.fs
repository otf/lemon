module UtilTest


open NaturalSpec
open System
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

[<Scenario>]
let ``Convert a NameValueCollection to list`` () =
  let col = System.Collections.Specialized.NameValueCollection ()
  col.Add ("Id", "10")
  col.Add ("Name", "otf")

  Given col
    |> When nameValueCollections2List
    |> It should equal [("Id", "10"); ("Name", "otf")]
    |> Verify
