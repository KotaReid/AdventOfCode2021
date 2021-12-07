module FileUtils

open System.IO

let private readFilesLines fileName =
    $"Inputs/{fileName}.txt"
    |> File.ReadAllLines

let readStrings fileName = 
    fileName
    |> readFilesLines
    |> Array.toList 

let readLinesAsNumber (fileName:string) =
    fileName
    |> readStrings
    |> List.map int

let readAsNumbers (fileName:string) =
    let x = 
        fileName
        |> readStrings
        |> List.head 

    x.Split ',' |> Array.map int |> Array.toList
    
    