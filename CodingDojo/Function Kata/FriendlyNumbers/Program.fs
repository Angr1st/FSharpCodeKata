// Learn more about F# at http://fsharp.org

open System

type HappySad=
    |Happy
    |Maybe of string
    |Sad

let splitString (x:String) =
    x.ToCharArray()

let charToInt (x:char)=
    Int32.Parse <| x.ToString()

let intTimesTwo (x:int)=
    pown x 2

let from10to20 = seq { 10..20}

let arrayOfIntIs1 (x:int []) =
    let result = Array.sum x
    if result = 1
        then Happy
    elif result = 2
        then Sad
        else Maybe <| result.ToString()

let fromStringToResult x =
    Array.map (charToInt >> intTimesTwo) (splitString x) |> arrayOfIntIs1

let doUntilHappyOrSad (x:HappySad)=
    match x with  
        |Happy -> Happy
        |Sad -> Sad
        |Maybe a -> a
    

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
