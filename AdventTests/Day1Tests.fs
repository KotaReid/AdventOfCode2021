namespace AdventTests

open NUnit.Framework
open AdventLib

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

    [<Test>]
    member this.shouldCountIncreasedDepths() =
        let expected = 7
        let actual = Day1.countOfIncreasedDepths depths
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.shouldCountIncreasedSlidingDepths() =
        let expected = 5

        let actual =
            Day1.countOfIncreasedSlidingDepths depths

        Assert.That(actual, Is.EqualTo(expected))
