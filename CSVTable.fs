   
type Row ={ 
    Name : string
    Strasse:string
    Ort:string
    Alter:string 
    }

let CreateRow (x:string) (seperator:char array) =
    let splitString = x.Split seperator
    if splitString.Length = 4
        then Some { Name=splitString.[0]; Strasse=splitString.[1]; Ort=splitString.[2]; Alter=splitString.[3]}
        else None

type ColumnLength= ColumnLength of int

let CreateColumnLength (x:int) =
    if x >= 0 
        then Some (ColumnLength x) 
        else None

type CSVTable ={
    HeaderRow:Row
    Rows:Row list
    LongestFirstColumnEntry:int
    LongestSecondColumnEntry:int
    LongestThirdColumnEntry:int
    LongestFourthCoulumnEntry:int
}
        
