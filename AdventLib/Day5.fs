namespace AdventLib

module Day5 = 
    type Orientation =
        | ZeroSlope
        | Diagonal

    type Point = {X:int; Y:int;}

    let createPoint x y = { X = x; Y = y}

    let parseLine (line:string) = 
        line.Split(" -> ") 
        |> Array.map (fun s -> s.Split ',')

    let parsePoint p = 
        {
            X = p |> Array.head |> int
            Y = p |> Array.last |> int
        }

    let range a b =
        if a <= b then 
            seq { a..b } 
        else 
            seq { a .. -1 .. b}

    let pointsFromLine (line:string) =
        let l = parseLine line
        let sp = l |> Array.head |> parsePoint
        let ep = l |> Array.last |> parsePoint

        let xSeq = range sp.X ep.X
        let ySeq = range sp.Y ep.Y

        if sp.X = ep.X then 
            (ySeq |> Seq.map (fun y -> {X = sp.X; Y = y}), ZeroSlope)
        else if sp.Y = ep.Y then
            (xSeq |> Seq.map (fun x -> {X = x; Y = sp.Y}), ZeroSlope)
        else
            (Seq.zip xSeq ySeq |> Seq.map (fun (x,y) -> {X = x; Y = y}), Diagonal)

    let safePoints p =
        p
        |> Seq.map fst 
        |> Seq.concat
        |> Seq.countBy id
        |> Seq.filter (fun (_, count) -> count >= 2)
        |> Seq.length

    let safePointsPart1 (lines:List<string>) = 
        lines 
        |> List.map pointsFromLine
        |> Seq.filter (fun (_, o) -> o = ZeroSlope)
        |> safePoints 

    let safePointsPart2 (lines:List<string>) = 
        lines 
        |> List.map pointsFromLine
        |> safePoints 