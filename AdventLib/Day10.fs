namespace AdventLib

module Day10 =
    type Stack = char list
    
    type SyntaxResult =
        | Corrupted of char
        | Incomplete of Stack
    
    let push stack c = c :: stack

    let pop stack = 
        match stack with
        | [] -> None
        | c::tail -> (c,tail) |> Some

    let closeFromOpen c =
        match c with
        | '{' -> '}'
        | '(' -> ')'
        | '[' -> ']'
        | '<' -> '>'

    let parseNavigationLine(line: string) =
        let rec op stack s = 
            match s with
            | [] -> Incomplete(stack)
            | c::rem -> 
                if "({[<" |> Seq.contains c then
                    op (push stack c) rem
                else 
                    match pop stack with
                    | None -> invalidOp "stack should not be empty"
                    | Some (expected, newStack) -> 
                        let closeMatch = closeFromOpen expected  
                        if (c <> closeMatch) then
                            Corrupted(c)
                        else
                            op newStack rem
        line 
        |> Seq.toList 
        |> op List.Empty

    let parseNavigationLines(lines: List<string>) =
        lines
        |> List.map (fun l -> l.Trim())
        |> List.map parseNavigationLine

    let scoreCorrupted c = 
        match c with
        | ')' -> 3 
        | ']' -> 57 
        | '}' -> 1197 
        | '>' -> 25137 

    let scoreIncomplete c = 
        match c with
        | ')' -> 1L
        | ']' -> 2L
        | '}' -> 3L
        | '>' -> 4L

    let corruptedScore (lines: List<string>) = 
        lines
        |> parseNavigationLines
        |> List.choose (function Corrupted c -> Some c | _ -> None)
        |> List.sumBy scoreCorrupted

    let incompleteScore (lines: List<string>) = 
        let scoreForLine stack =
            stack 
            |> List.map closeFromOpen
            |> List.fold (fun t c -> t * 5L + (scoreIncomplete c)) 0L

        let scores = 
            lines
            |> parseNavigationLines
            |> List.choose (function Incomplete stack -> Some stack | _ -> None)
            |> List.map scoreForLine
            |> List.sortDescending

        scores[scores.Length / 2]
