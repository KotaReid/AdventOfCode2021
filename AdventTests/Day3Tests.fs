namespace AdventTests

open NUnit.Framework
open AdventLib
open Day3

[<TestFixture>]
type Day3Tests() = 
    let diagonstics = 
        [
            "00100"
            "11110"
            "10110"
            "10111"
            "10101"
            "01111"
            "00111"
            "11100"
            "10000"
            "11001"
            "00010"
            "01010"
        ]

    [<Test>]
    member this.ShouldCalculateGammaRate() =
        let expected = 22;
        let actual = gammaRate diagonstics
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldCalculateEpsilonRate() =
        let expected = 9;
        let actual = eplisonRate diagonstics
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldCalculateOxygenGeneratorRating() =
        let expected = 23;
        let actual = oxygenGeneratorRating diagonstics
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldCalculateCO2ScrubbingRating() =
        let expected = 10;
        let actual = co2ScurbbingRating diagonstics
        Assert.That(actual, Is.EqualTo(expected))