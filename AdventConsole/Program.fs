open System
open AdventLib

let executeDay n =
    match n with
    | "1" -> FileUtils.readLinesAsNumber "Day1" |> Day1.result
    | "2" -> FileUtils.readLines "Day2" |> Day2.result
    | "3" -> FileUtils.readLines "Day3" |> Day3.result
    | _ -> "Invalid Option"

let rec promptUser () =
    try
        Console.Write "Day to Execute [q to quit]: "

        let input = Console.ReadLine().Trim()

        match input with
        | "q" -> 0
        | _ ->
            executeDay input |> Console.WriteLine
            Console.WriteLine()
            promptUser ()
    with
    | ex ->
        Console.WriteLine(ex.ToString())
        1

[<EntryPoint>]
let main argv = promptUser ()
