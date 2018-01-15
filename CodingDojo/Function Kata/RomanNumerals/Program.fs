// Learn more about F# at http://fsharp.org

open System

type RomanNumerals =
    |I
    |V
    |X
    |L
    |C
    |D
    |M

let split (x:string) =
    [for c in x -> c]

let createRomanNumeral x =
    match x with
    |'I' -> Some I
    |'V' -> Some V
    |'X' -> Some X
    |'L' -> Some L
    |'C' -> Some C
    |'D' -> Some D
    |'M' -> Some M
    |_ -> None

let cleanOutNone (x:RomanNumerals option list) =
    List.choose id x

let turnToInt (x:RomanNumerals) =
    match x with
    |I -> 1
    |V -> 5
    |X -> 10
    |L -> 50
    |C -> 100
    |D -> 500
    |M -> 1000

let addOrSubstract (x:int) (y:int) =
    if x >= y 
        then (x+y)
    elif x = 0 && y >=1
        then y
    else (x-1)

let turnStringIntoInt (x:string) =
    split x |> List.map createRomanNumeral |> cleanOutNone |> List.map turnToInt

let glueTogether (x:string[]) =
    let arrayOfIntList = Array.map (turnStringIntoInt >> (List.fold addOrSubstract 0)) x
    arrayOfIntList

let newLine = "\n"

let printIntArray (x:int[]) =
    Array.map (fun y -> y.ToString()) x |> Array.reduce (fun c v -> c + newLine + v)

[<EntryPoint>]
let main argv =
    printfn "%s" <| (glueTogether argv |> printIntArray)
    0 // return an integer exit code
