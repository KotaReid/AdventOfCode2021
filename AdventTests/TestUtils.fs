module TestUtils

type DataSource = 
    | Example = 0 
    | File = 1

let dataFromSource exampleData fileData dataSource = 
    match dataSource with
    | DataSource.Example -> exampleData
    | DataSource.File -> fileData
    | _ -> invalidArg (nameof dataSource) ("Unsupported dataSource")