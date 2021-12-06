namespace AdventTests

open NUnit.Framework
open AdventLib.Day1
open TestUtils

[<TestFixture>]
type Day1Tests() =
    let depths =
        [ 199
          200
          208
          210
          200
          207
          240
          269
          260
          263 ]

    let fileDepths = FileUtils.readLinesAsNumber "Day1"

    let data = dataFromSource depths fileDepths

    [<TestCase(DataSource.Example, ExpectedResult = 7)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1446)>]
    member this.shouldCountIncreasedDepths(dataSource) =
        data dataSource |> countOfIncreasedDepths

    [<TestCase(DataSource.Example, ExpectedResult = 5)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1486)>]
    member this.shouldCountIncreasedSlidingDepths(dataSource) =
        data dataSource |> countOfIncreasedSlidingDepths
