namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day10

[<TestFixture>]
type Day10Tests() = 
    let exampleInput = FileUtils.readStrings "Day10Example"
    let problemInput = FileUtils.readStrings "Day10"

    let data = dataFromSource exampleInput problemInput

    [<TestCase(DataSource.Example, ExpectedResult = 26397)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 367227)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> corruptedScore

    [<TestCase(DataSource.Example, ExpectedResult = 288957L)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 3583341858L)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> incompleteScore