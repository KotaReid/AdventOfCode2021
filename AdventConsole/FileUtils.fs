module FileUtils

open System.IO

let readLines (fileName: string) = 
    $"Inputs/{fileName}.txt"
    |> File.ReadAllLines

let readLinesAsNumber (fileName:string) =
    fileName
    |> readLines
    |> Seq.map int