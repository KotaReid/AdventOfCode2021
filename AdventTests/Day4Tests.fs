namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day4

[<TestFixture>]
type Day4Tests() = 
    let exampleGame = FileUtils.readLines "Day4Example"
    let problemGame = FileUtils.readLines "Day4"

    let data = dataFromSource exampleGame problemGame

    [<TestCase(DataSource.Example, ExpectedResult = 4512)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 72770)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> playBingo |> fst

    [<TestCase(DataSource.Example, ExpectedResult = 1924)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 13912)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> playBingo |> snd