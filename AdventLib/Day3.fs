namespace AdventLib

open System

module Day3 = 
    type Diagonstic = string

    let bitCounts pos diagnostics = 
        diagnostics 
        |> List.countBy (fun (x: Diagonstic) -> x[pos])
        |> List.sortBy snd

    let binaryStringToInt b = Convert.ToUInt32(b, 2)

    let gammaRate (diagnostics: list<Diagonstic>) =
        let length = Seq.head diagnostics |> String.length
        
        seq { for i = 0 to length - 1 do yield (bitCounts i diagnostics)[1] |> fst}
        |> Seq.toArray
        |> String
        |> binaryStringToInt
    
    let eplisonRate (diagnostics: list<Diagonstic>) = 
        let length = List.head diagnostics |> String.length
        let mask = (1u <<< length) - 1u;
        ~~~ (gammaRate diagnostics) &&& mask

    let ratingBy pos pairValue diagnostics =
        let rec x i diag:Diagonstic =
            match diag with
            | [d] -> d
            | [d1;d2] -> if d1[i] = pairValue then d1 else d2
            | d -> 
                let commonBits = bitCounts i d
                let commonBit = if(snd commonBits[0] = snd commonBits[1]) then pairValue else commonBits[pos] |> fst
                d |> List.filter (fun x -> x[i] = commonBit) |> x (i+1)

        x 0 diagnostics |> binaryStringToInt

    let oxygenGeneratorRating = ratingBy 1 '1'
    let co2ScurbbingRating = ratingBy 0 '0'

    let result (diagnostics: list<string>) = 
        let powerConsumption = gammaRate diagnostics * eplisonRate diagnostics
        let lifeSupportRating = oxygenGeneratorRating diagnostics * co2ScurbbingRating diagnostics

        let part1 = powerConsumption
        let part2 = lifeSupportRating

        sprintf $"Part 1 %i{part1}{Environment.NewLine}"
              + $"Part 2 %i{part2}"