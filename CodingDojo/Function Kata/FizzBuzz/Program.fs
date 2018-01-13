// Learn more about F# at http://fsharp.org

open System

type FizzBuzz=
    |Fizz of string * int
    |Buzz of string * int
    |FizzBuzz of string * int * int
    |Number of int

let OneToHundred = [1 .. 100]

let NewLine = "\n"



[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
