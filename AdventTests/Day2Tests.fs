namespace AdventTests

open NUnit.Framework
open AdventLib.Day2
open TestUtils
open System

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

    let fileCommands = 
        FileUtils.readLines "Day2"
        |> List.map (fun s -> 
            s.Split " " 
            |> Seq.pairwise
            |> Seq.head
            |> (fun (a,b) -> (a,int b)))

    let data = dataFromSource commands fileCommands

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

    [<TestCase(DataSource.Example, ExpectedResult = 150)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 1989014)>]
    member this.ShouldMovePosWithSequenceOfCommands(dataSource) =
         data dataSource |> totalCoursePosition Sub.Zero

    [<TestCase(DataSource.Example, ExpectedResult = 900)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 2006917119)>]
    member this.ShouldMoveAimWithSequenceOfCommands(dataSource) =
        data dataSource |> totalCourseAim Sub.Zero 
