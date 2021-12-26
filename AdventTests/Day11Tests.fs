namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day11

[<TestFixture>]
type Day11Tests() = 
    let exampleInput = FileUtils.readStrings "Day11Example"
    let problemInput = FileUtils.readStrings "Day11"

    let data = dataFromSource exampleInput problemInput

    [<TestCase(DataSource.Example, ExpectedResult = 1656)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1642)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> totalFlashes 100

    [<TestCase(DataSource.Example, ExpectedResult = 195)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 320)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> flashSynced 200