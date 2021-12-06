module TestUtils

type DataSource = 
    | Example = 0 
    | Problem = 1

let dataFromSource exampleData fileData dataSource = 
    match dataSource with
    | DataSource.Example -> exampleData
    | DataSource.Problem -> fileData
    | _ -> invalidArg (nameof dataSource) ("Unsupported dataSource")