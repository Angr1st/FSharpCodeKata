// Learn more about F# at http://fsharp.org

open System

type FizzBuzzType=
    |Fizz of string
    |Buzz of string 
    |FizzBuzz of string
    |Number of string

let CreateFizzBuzz (x:int) =
    if x % 3 = 0 && x % 5 = 0
        then FizzBuzz "FizzBuzz" 
    elif x % 5 = 0
        then Buzz "Buzz"
    elif x % 3 = 0
        then Fizz "Fizz"
        else Number <| Convert.ToString(x)


let FizzBuzzToString x = 
    match x with
    | FizzBuzz r-> r
    | Fizz r-> r
    | Buzz r-> r
    | Number r-> r 


let OneToHundred = [1 .. 100]

let NewLine = "\n"

let PrintFizzBuzz x =
    List.map (CreateFizzBuzz >> FizzBuzzToString) x |> String.concat NewLine

[<EntryPoint>]
let main argv =
    printfn "%s" <| PrintFizzBuzz OneToHundred
    0 // return an integer exit code
