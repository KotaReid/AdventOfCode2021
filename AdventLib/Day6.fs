namespace AdventLib

module Day6 = 
    let toFishCountArray fish = 
        let fishCounts = Array.create 9 0L

        fish 
        |> List.countBy id
        |> List.iter (fun (timer, count) -> fishCounts[timer] <- count)

        fishCounts
        
    let simulateDay (fishCounts: array<int64>) =
        let fishToSpawn = fishCounts[0]

        fishCounts[0] <- fishCounts[1]
        fishCounts[1] <- fishCounts[2]
        fishCounts[2] <- fishCounts[3]
        fishCounts[3] <- fishCounts[4]
        fishCounts[4] <- fishCounts[5]
        fishCounts[5] <- fishCounts[6] 
        fishCounts[6] <- fishCounts[7] + fishToSpawn
        fishCounts[7] <- fishCounts[8]
        fishCounts[8] <- fishToSpawn

        fishCounts

    let simulateDays days fish =
        let fishCounts = fish |> toFishCountArray

        {1..days}
        |> Seq.toList
        |> List.fold (fun f _ ->  simulateDay f) fishCounts
        |> Array.sum
            