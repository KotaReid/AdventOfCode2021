namespace AdventLib

module Day8 =
    type Digit = 
        { Value:string; SignalPattern: char Set}
        member this.Count = this.SignalPattern.Count;

    type JournalEntry = { Input: Digit list; Output: Digit list}
        
    let convertToDigit (s: string) =
        let value = 
            match s.Length with
            | 2 -> "1"
            | 3 -> "7"
            | 4 -> "4" 
            | 7 -> "8" 
            | _ -> ""

        {Value = value; SignalPattern = s |> Set.ofSeq}

    let convertToDigits (s: string) =
        s.Split ' '
        |> Array.map convertToDigit
        |> Array.toList
    
    let parseJournalEntry (s: string) =
        let split = s.Split " | "
        { Input = convertToDigits split[0]; Output = convertToDigits split[1] }

    let parseJournalEntries (input: string list) =
        input
        |> List.map parseJournalEntry

    let easyDigitCount (input: string list) = 
        input
        |> parseJournalEntries
        |> List.map (fun line -> line.Output)
        |> List.sumBy (fun x -> x |> List.filter (fun digit -> digit.Value.Length <> 0) |> List.length)

    let solveDigitLengthOfSix d one four = 
        let value = 
            if Set.isProperSubset four.SignalPattern d.SignalPattern then "9"
            else if Set.isProperSubset one.SignalPattern d.SignalPattern then "0"
            else "6"

        {d with Value = value}

    let solveDigitLengthOfFive d one six = 
        let value = 
            if Set.isProperSuperset six.SignalPattern d.SignalPattern then "5"
            else if Set.isProperSubset one.SignalPattern d.SignalPattern then "3"
            else "2"

        {d with Value = value}

    let solveJournalEntry(entry: JournalEntry) =
        let one = entry.Input |> List.find (fun x -> x.Value = "1") 
        let four = entry.Input |> List.find (fun x -> x.Value = "4")

        let sixResults = entry.Input |> List.filter (fun x -> x.Count = 6) |> List.map (fun d -> solveDigitLengthOfSix d one four)
        let six = sixResults |> List.find (fun x -> x.Value =  "6")

        let fiveResults = entry.Input |> List.filter (fun x -> x.Count = 5) |> List.map (fun d -> solveDigitLengthOfFive d one six)

        let results = entry.Input |> List.filter (fun x -> x.Value.Length <> 0) |> List.append sixResults |> List.append fiveResults

        entry.Output 
        |> List.map (fun o -> List.find (fun r -> r.SignalPattern = o.SignalPattern) results) 
        |> List.map (fun t -> t.Value)
        |> String.concat ""
        |> int

    let decode (input: string list) = 
        parseJournalEntries input
        |> List.map solveJournalEntry
        |> List.sum
        
