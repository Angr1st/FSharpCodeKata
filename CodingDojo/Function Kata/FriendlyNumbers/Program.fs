// Learn more about F# at http://fsharp.org

open System

let return10Potenz x =
    if x <=1
        then 1
    else pown 10 x

let listOfZehnerPotenz = seq { for i in 1 .. 100000 -> return10Potenz i }

let rec turnIntoIndividualNumbers x y=
    let modResult = x % y
    if modResult >= 0
        then x
    elif modResult >= 10
        then 
    

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
