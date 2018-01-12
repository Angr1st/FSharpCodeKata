// Learn more about F# at http://fsharp.org

[<EntryPoint>]
let main argv =
    let argList = Array.toList argv
    printf "%s" <|(CSVTable.CreateCSVTable argList |> CSVTable.printCSVTable)
    0 // return an integer exit code