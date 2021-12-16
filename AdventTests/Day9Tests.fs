namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day9

[<TestFixture>]
type Day9Tests() = 
    let exampleInput = FileUtils.readStrings "Day9Example"
    let problemInput = FileUtils.readStrings "Day9"

    let data = dataFromSource exampleInput problemInput

    [<TestCase(DataSource.Example, ExpectedResult = 15)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 600)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> riskLevels

    [<TestCase(DataSource.Example, ExpectedResult = 1134)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 987840)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> maxBasins