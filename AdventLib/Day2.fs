namespace AdventLib

open System

module Day2 =
    type Sub = 
        { Horizontal:int; Depth:int; Aim:int; }
        static member Zero = { Horizontal=0; Depth=0; Aim=0; }

    let private mv forwardF verticalF sub (command, size) =
            match command with
            | "forward" -> forwardF sub size
            | "down" -> verticalF sub +size
            | "up" -> verticalF sub -size
            | _ -> invalidArg (nameof command) (sprintf "Value passed in was %s." command)

    let moveWithPosition = 
        let forwardCommand sub size = 
            { sub with Horizontal = sub.Horizontal + size }
        let verticalCommand sub size = 
            { sub with Depth = sub.Depth + size }

        mv forwardCommand verticalCommand
    
    let moveWithAim = 
        let forwardcommand sub size = 
            { sub with Horizontal = sub.Horizontal + size; Depth = sub.Aim * size + sub.Depth}
        let verticalCommand sub size = 
            { sub with Aim = sub.Aim + size }

        mv forwardcommand verticalCommand

    let moveCourseWithPosition = Seq.fold moveWithPosition
    let moveCourseWithAim = Seq.fold moveWithAim

    let result (unparsedCommands: seq<string>) =
        let commands = 
            unparsedCommands
            |> Seq.map (fun s -> 
                s.Split " " 
                |> Seq.pairwise
                |> Seq.head
                |> (fun (a,b) -> (a,int b)))

        let totalSubPos subPosition = subPosition.Horizontal * subPosition.Depth;
        
        let part1 = moveCourseWithPosition Sub.Zero commands |> totalSubPos
        let part2 = moveCourseWithAim Sub.Zero commands |> totalSubPos

        sprintf $"Part 1 %i{part1}{Environment.NewLine}"
              + $"Part 2 %i{part2}"