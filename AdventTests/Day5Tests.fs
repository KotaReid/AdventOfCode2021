namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day5

[<TestFixture>]
type Day5Tests() = 
    let exampleGame = FileUtils.readStrings "Day5Example"
    let problemGame = FileUtils.readStrings "Day5"

    let data = dataFromSource exampleGame problemGame

    [<TestCase(DataSource.Example, ExpectedResult = 5)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 5585)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> safePointsPart1

    [<TestCase(DataSource.Example, ExpectedResult = 12)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 17193)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> safePointsPart2