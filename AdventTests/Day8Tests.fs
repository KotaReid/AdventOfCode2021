namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day8

[<TestFixture>]
type Day8Tests() = 
    let exampleInput = FileUtils.readStrings "Day8Example"
    let problemInput = FileUtils.readStrings "Day8"

    let data = dataFromSource exampleInput problemInput

    [<TestCase(DataSource.Example, ExpectedResult = 26)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 344)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> easyDigitCount

    [<TestCase(DataSource.Example, ExpectedResult = 61229)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1048410)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> decode