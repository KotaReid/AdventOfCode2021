module FileUtils

open System.IO

let readLines (fileName: string) = 
    $"Inputs/{fileName}.txt"
    |> File.ReadAllLines
    |> Array.toList

let readLinesAsNumber (fileName:string) =
    fileName
    |> readLines
    |> Seq.map int