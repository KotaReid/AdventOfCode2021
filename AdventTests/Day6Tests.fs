namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day6

[<TestFixture>]
type Day6Tests() = 
    let exampleFish = [3;4;3;1;2]
    let problemFish = FileUtils.readAsNumbers "Day6"

    let data = dataFromSource exampleFish problemFish

    [<TestCase(DataSource.Example, ExpectedResult = 5934L)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 353079L)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> simulateDays 80

    [<TestCase(DataSource.Example, ExpectedResult = 26984457539L)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1605400130036L)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> simulateDays 256