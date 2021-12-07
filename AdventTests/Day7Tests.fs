namespace AdventTests

open NUnit.Framework
open TestUtils
open AdventLib.Day7

[<TestFixture>]
type Day7Tests() = 
    let exampleCrabs = [16;1;2;0;4;2;7;1;2;14]
    let problemCrabs = FileUtils.readAsNumbers "Day7"

    let data = dataFromSource exampleCrabs problemCrabs

    [<TestCase(DataSource.Example, ExpectedResult = 37)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 343441)>]
    member this.ShouldSolvePart1(dataSource) =
        data dataSource |> minFuelConstant

    [<TestCase(DataSource.Example, ExpectedResult = 168)>]
    [<TestCase(DataSource.Problem, ExpectedResult = 98925151)>]
    member this.ShouldSolvePart2(dataSource) =
        data dataSource |> minFuelChanging