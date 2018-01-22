// Learn more about F# at http://fsharp.org

open System

type HappySadMaybe=
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

type RecordInitial= {
    InitialNumber : string
    Result : HappySadMaybe
}

let createRecordInitial x y =
    { InitialNumber = x; Result =y}

let arrayOfIntIs1 (x:int []) =
    let result = Array.sum x
    if result = 1
        then Happy
    elif result = 2
        then Sad
        else Maybe <| result.ToString()

let fromStringToResult (x: RecordInitial) y=
    Array.map (charToInt >> intTimesTwo) (splitString y) |> arrayOfIntIs1 |> createRecordInitial x.InitialNumber

let doUntilHappyOrSad (x:HappySadMaybe)=
    match x with  
        |Happy -> false
        |Sad -> false
        |Maybe _ -> true
    
let turnToStringOption (x:HappySadMaybe) =
    match x with
    |Maybe a -> Some a
    |Happy | Sad -> None


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
