namespace AdventLib

module Day9 = 
    let getNeighbor map r c = 
        if r < 0 || r >= Array2D.length1 map || c < 0 || c >= Array2D.length2 map then
            (9, -1, -1)
        else
            (map[r,c], r, c)

    let getUnvistedNeighbors (map:int[,]) r c (visited: (int*int) list)=
        [
            if visited |> Seq.contains (r-1,c) |> not then 
                yield getNeighbor map (r-1) c
            if visited |> Seq.contains (r+1,c) |> not then
                yield getNeighbor map (r+1) c
            if visited |> Seq.contains (r, c+1) |> not then
                yield getNeighbor map r (c+1)
            if visited |> Seq.contains (r,(c-1)) |> not then
                yield getNeighbor map r (c-1)
        ]

    let isLowPoint (map:int[,]) r c = 
        List.empty |> getUnvistedNeighbors map r c  |> List.forall (fun (n, _, _) -> map[r,c] < n)

    let getLowPoints map = 
        let rows = Array2D.length1 map - 1
        let cols = Array2D.length2 map - 1
        [ 
            for r in 0..rows do
                for c in 0..cols do
                    if isLowPoint map r c then 
                        yield (map[r,c], r, c)
        ]

    let toHeightMap (lines: List<string>) = 
        let parseLine (line:string) =
            line
            |> Seq.map (fun c -> string c |> int)
            |> Seq.toArray 

        lines
        |> List.map parseLine
        |> array2D

    let riskLevels (lines: List<string>) =
        lines
        |> toHeightMap
        |> getLowPoints 
        |> List.sumBy (fun (v, _, _) -> v + 1)

    let basinLength (input: int[,]) (row, col) =
        let rec loop visited queue = 
            match queue with
            | [] -> visited |> Seq.length
            | (rowN, colN)::qTail -> 
                let neighbors = 
                    visited
                    |> getUnvistedNeighbors input rowN colN
                    |> List.choose (fun (v, r, c) -> if v <> 9 then (r,c) |> Some else None)

                loop (visited @ neighbors) (neighbors @ qTail)
        
        loop List.empty [(row,col)]

    let maxBasins (lines: List<string>) =
        let map = lines |> toHeightMap
            
        map 
        |> getLowPoints
        |> Seq.map (fun (_, row, col) -> basinLength map (row, col))
        |> Seq.sortDescending
        |> Seq.truncate 3
        |> Seq.reduce (*)