namespace AdventTests

open NUnit.Framework
open AdventLib
open System
open Day2

[<TestFixture>]
type Day2Tests() =
    let commands = 
        [
            ("forward", 5)
            ("down", 5)
            ("forward", 8)
            ("up", 3)
            ("down", 8)
            ("forward", 2)
        ]

    let assertInvalidCommand f =
        let command = ("badCommand", 0)
        let action() = f Sub.Zero command |> ignore
        Assert.Throws<ArgumentException> action |> ignore

    [<Test>]
    member this.ShouldHandleInvalidCommandOnMoveWithPosition() = 
        assertInvalidCommand moveWithPosition

    [<Test>]
    member this.ShouldHandleInvalidCommandOnMoveWithAim() = 
        assertInvalidCommand moveWithAim

    [<Test>]
    member this.ShouldMoveSubForwardWithPosition() =
        let expected = { Sub.Zero with Horizontal = 5 }

        let command = ("forward", 5)
        let actual = moveWithPosition Sub.Zero command

        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldMoveSubDownWithPosition() =
        let expected = { Sub.Zero with Depth = 5 }

        let command = ("down", 5)
        let actual = moveWithPosition Sub.Zero command

        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldMoveSubUpWithPostion() =
        let expected = { Sub.Zero with Depth = -5 }

        let command = ("up", 5)
        let actual = moveWithPosition Sub.Zero command

        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldMoveSubForwardWithAim() =
        let expected : Sub = { Horizontal = 13; Depth = 40; Aim = 5;}

        let sub: Sub = { Horizontal = 5; Depth = 0; Aim = 5;}
        let command = ("forward", 8)
        let actual = moveWithAim sub command

        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldMoveWithSequenceOfCommands() =
        let expected : Sub = {Horizontal = 15; Depth = 10; Aim = 0}

        let actual = moveCourseWithPosition Sub.Zero commands

        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.ShouldMoveWithAimWithSequenceOfCommands() =
        let expected : Sub = {Horizontal = 15; Depth = 60; Aim = 10}

        let actual = moveCourseWithAim Sub.Zero commands

        Assert.That(actual, Is.EqualTo(expected))

