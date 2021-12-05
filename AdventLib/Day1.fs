namespace AdventLib

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