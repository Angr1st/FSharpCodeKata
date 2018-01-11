module CSVTable
type ColumnLength= ColumnLength of int

let CreateColumnLength (x:int) =
    if x >= 0 
        then Some (ColumnLength x) 
        else None

type Row={ 
    Name:string
    Strasse:string
    Ort:string
    Alter:string 
    FirstColumnLength:ColumnLength
    SecondColumnLength:ColumnLength
    ThirdColumnLength:ColumnLength
    FourthColumnLength:ColumnLength
    }

let CreateRow (x:string) (seperator:char array) =
    let splitString = x.Split seperator
    if splitString.Length = 4
        then Some { Name=splitString.[0]; Strasse=splitString.[1]; Ort=splitString.[2]; Alter=splitString.[3]; FirstColumnLength=ColumnLength splitString.[0].Length; SecondColumnLength=ColumnLength splitString.[1].Length; ThirdColumnLength=ColumnLength splitString.[2].Length; FourthColumnLength=ColumnLength splitString.[3].Length; }
        else None

type CSVTable ={
    HeaderRow:Row
    Rows:Row list
    LongestFirstColumnEntry:ColumnLength
    LongestSecondColumnEntry:ColumnLength
    LongestThirdColumnEntry:ColumnLength
    LongestFourthCoulumnEntry:ColumnLength
}

let CreateCSVTable (x:string list) =
    let z = x |> List.map (CreateRow i ';') |> List.filter (fun r-> match r with 
        |Row -> true 
        |None -> false)
    if !z.IsEmpty
        then None
        Else Some {HeaderRow=z.Head; Rows=z|>List.except z.Head; LongestFirstColumnEntry= z |> List.maxBy (fun y -> y.LongestFirstColumnEntry); LongestSecondColumnEntry= z |> List.maxBy (fun y -> y.LongestSecondColumnEntry); LongestThirdColumnEntry= z |> List.maxBy (fun y -> y.LongestThirdColumnEntry); LongestFourthColumnEntry= z |> List.maxBy (fun y -> y.LongestFourthColumnEntry);}

