namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day6

[<TestFixture>]
type Day6Tests() = 
    let exampleFish = [3;4;3;1;2]
    let problemFish = 
        [
            4;5;3;2;3;3;2;4;2;1
            2;4;5;2;2;2;4;1;1;1
            5;1;1;2;5;2;1;1;4;4
            5;5;1;2;1;1;5;3;5;2
            4;3;2;4;5;3;2;1;4;1
            3;1;2;4;1;1;4;1;4;2
            5;1;4;3;5;2;4;5;4;2
            2;5;1;1;2;4;1;4;4;1
            1;3;1;2;3;2;5;5;1;1
            5;2;4;2;2;4;1;1;1;4
            2;2;3;1;2;4;5;4;5;4
            2;3;1;4;1;3;1;2;3;3
            2;4;3;3;3;1;4;2;3;4
            2;1;5;4;2;4;4;3;2;1
            5;3;1;4;1;1;5;4;2;4
            2;2;4;4;4;1;4;2;4;1
            1;3;5;1;5;5;1;3;2;2
            3;5;3;1;1;4;4;1;3;3
            3;5;1;1;2;5;5;5;2;4
            1;5;1;2;1;1;1;4;3;1
            5;2;3;1;3;1;4;1;3;5
            4;5;1;3;4;2;1;5;1;3
            4;5;5;2;1;2;1;1;1;4
            3;1;4;2;3;1;3;5;1;4
            5;3;1;3;3;2;2;1;5;5
            4;3;2;1;5;1;3;1;3;5
            1;1;2;1;1;1;5;2;1;1
            3;2;1;5;5;5;1;1;5;1
            4;1;5;4;2;4;5;2;4;3
            2;5;4;1;1;2;4;3;2;1
        ]

    let data = dataFromSource exampleFish problemFish

    [<TestCase(DataSource.Example, ExpectedResult = 5934L)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 353079L)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> simulateDays 80

    [<TestCase(DataSource.Example, ExpectedResult = 26984457539L)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1605400130036L)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> simulateDays 256