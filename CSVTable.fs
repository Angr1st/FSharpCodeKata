module CSVTable
open System.Security.Principal
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

//let TurnStringListIntoRowList (x:string list)= 

let MapCreateRow (x:string list) =
    List.map (fun z-> CreateRow z [|';'|]) x

let RowToFirstColumnLength x = 
   let t = x |> List.maxBy (fun y -> y.FirstColumnLength)
   t.FirstColumnLength 

let RowToSecondColumnLength x = 
   let t = x |> List.maxBy (fun y -> y.SecondColumnLength)
   t.SecondColumnLength 

let RowToThirdColumnLength x = 
   let t = x |> List.maxBy (fun y -> y.ThirdColumnLength)
   t.ThirdColumnLength

let RowToFourthColumnLength x = 
   let t = x |> List.maxBy (fun y -> y.FourthColumnLength)
   t.FourthColumnLength  


let CreateCSVTable (x:string list) =
    let z = MapCreateRow x |> List.choose id 
    {HeaderRow=z.Head; Rows=z|>List.except [z.Head]; LongestFirstColumnEntry= RowToFirstColumnLength z; LongestSecondColumnEntry= RowToSecondColumnLength z ; LongestThirdColumnEntry= RowToThirdColumnLength z ; LongestFourthCoulumnEntry = RowToFourthColumnLength z ;}

