namespace AdventLib

module Day11 =
    let getNeighborDirections r c = 
        [|
            (r-1,c-1)
            (r-1,c)
            (r-1,c+1)
            (r,c-1)
            (r,c+1)
            (r+1,c-1)
            (r+1,c)
            (r+1,c+1)
        |]

    let toDumboOctiMap (lines: List<string>) =
        let parseLine (line:string) =
            line
            |> Seq.map (fun c -> string c |> int)
            |> Seq.toArray 

        lines
        |> List.map parseLine
        |> array2D

    let incrementNeighborAndCheckFlash map r c = 
        if r >= 0 && r < Array2D.length1 map && c >= 0 && c < Array2D.length2 map && map[r,c] <> 0 then
            map[r,c] <- map[r,c] + 1
            if map[r,c] > 9 then
                map[r,c] <- 0
                (r,c) |> Some
            else 
                None
        else
            None

    let doStep (map:int[,]) = 
        let mutable flashes = 0
        
        let initialFlashes = 
            [|
                for r in 0..Array2D.length1 map - 1 do
                    for c in 0..Array2D.length2 map - 1 do
                        map[r,c] <- map[r,c] + 1
                        if map[r,c] > 9 then
                            map[r,c] <- 0
                            flashes <- flashes + 1
                            yield (r,c)
            |]

        let rec handleFlashes (flashed: (int*int) array) = 
            let f (r,c)= 
                getNeighborDirections r c 
                |> Array.choose (fun (r',c') -> incrementNeighborAndCheckFlash map r' c') 
            
            if Array.length flashed = 0 then ()
            else
                let p = 
                    flashed
                    |> Array.map f
                    |> Array.concat 

                flashes <- flashes + Array.length p
                handleFlashes p
        
        handleFlashes initialFlashes
        flashes

    let printMap map = 
        printfn ""
        for r = 0 to Array2D.length1 map - 1 do
            printfn ""
            for c = 0 to Array2D.length2 map - 1 do
                printf "%A " map[r, c]

    let totalFlashes steps (lines: List<string>) =
        let map = lines |> toDumboOctiMap

        let rec runStep fl step =
            if step = steps then 
                fl
            else 
                let flashes = doStep map
                printMap map
                runStep (flashes+fl) (step+1)

        runStep 0 0

    let flashSynced steps (lines: List<string>) = 
        let map = lines |> toDumboOctiMap
        
        let rec runStep fl step =
            let flashes = doStep map
            printMap map

            if flashes = 100 then
                step+1
            else
                runStep (flashes+fl) (step+1)
        
        runStep 0 0
