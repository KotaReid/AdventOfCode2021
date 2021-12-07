namespace AdventLib

module Day7 =
    let delta a b = 
        a - b |> abs

    let sumTo a b =
         let d = delta a b
         {1..d} |> Seq.sum

    let constantFuels pos crabs = crabs |> List.sumBy (fun c -> delta c pos)
    let variableFuels pos crabs = crabs |> List.sumBy (fun c -> sumTo c pos)

    let minFuelBy f l = l |> List.map f |> List.min
    let minFuelByConstant l = minFuelBy (fun pos -> constantFuels pos l)
    let minFuelByVariable l = minFuelBy (fun pos -> variableFuels pos l)

    let minFuelConstant crabs =
        crabs
        |> List.distinct
        |> minFuelByConstant crabs

    let minFuelChanging crabs =
        let twoSmallestFuels = 
            crabs 
            |> List.distinct
            |> List.map (fun pos -> (variableFuels pos crabs, pos))
            |> List.sortBy fst
            |> List.take 2

        let pos1 = snd twoSmallestFuels[0]
        let pos2 = snd twoSmallestFuels[1]
        let d = delta pos1 pos2

        if d = 1 then 
            snd twoSmallestFuels[0]
        else if pos1 <= pos2 then
            [pos1..pos2] |> minFuelByVariable crabs
        else
            [pos1..pos2] |> minFuelByVariable crabs