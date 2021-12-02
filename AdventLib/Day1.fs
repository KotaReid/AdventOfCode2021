namespace AdventLib

open System

module Day1 =
    let countOfIncreasedDepths (depths: seq<int>) =
        depths
        |> Seq.pairwise
        |> Seq.filter (fun (a, b) -> b > a)
        |> Seq.length

    let countOfIncreasedSlidingDepths (depths: seq<int>) =
        depths
        |> Seq.windowed 3
        |> Seq.map Array.sum
        |> countOfIncreasedDepths

    let result (depths: seq<int>) =
        let part1 = countOfIncreasedDepths depths
        let part2 = countOfIncreasedSlidingDepths depths

        sprintf $"Part 1 %i{part1}{Environment.NewLine}"
        + $"Part 2 %i{part2}"
