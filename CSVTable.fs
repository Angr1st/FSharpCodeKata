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

let minus = "-"

let addPlus x = x + "+"

let NumberOfMinusPlusPlus x = String.replicate x minus |> addPlus

let whiteSpace = " "

let newLine = "\n"

let columnSeperator = "|"

let CreateSeperationRow x y z t = 
    NumberOfMinusPlusPlus x + NumberOfMinusPlusPlus y + NumberOfMinusPlusPlus z + NumberOfMinusPlusPlus t + newLine

let PrintRowPart content columnWidth fillUpString endString=
    content + (String.replicate (columnWidth - content.Length) fillUpString) + endString

let BakedPrintRowPart content columnWidth endString = PrintRowPart content columnWidth whiteSpace endString

let PrintRow row widthFirstColumn widthSecondColumn widthThirdColumn widthFourthColumn =
    let first = BakedPrintRowPart row.Name widthFirstColumn columnSeperator
    let second = BakedPrintRowPart row.Strasse widthSecondColumn  columnSeperator
    let third = BakedPrintRowPart row.Ort widthThirdColumn columnSeperator
    let fourth = BakedPrintRowPart row.Alter widthFourthColumn columnSeperator + newLine
    first + second + third + fourth

let printCSVTable (x:CSVTable) =
    let headerRowString = PrintRow x.HeaderRow x.LongestFirstColumnEntry x.LongestSecondColumnEntry x.LongestThirdColumnEntry x.LongestFourthCoulumnEntry
    let transitionRow = CreateSeperationRow x.LongestFirstColumnEntry x.LongestSecondColumnEntry x.LongestThirdColumnEntry x.LongestFourthCoulumnEntry
    let dataRows = List.map (fun y -> PrintRow y x.LongestFirstColumnEntry x.LongestSecondColumnEntry x.LongestThirdColumnEntry x.LongestFourthCoulumnEntry ) x.Rows
    headerRowString + transitionRow + String.concat "" dataRows