namespace AdventLib

module Day2 =
    type Sub = 
        { Horizontal:int; Depth:int; Aim:int; }
        static member Zero = { Horizontal=0; Depth=0; Aim=0; }

    let subTotal sub = sub.Horizontal * sub.Depth

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

    let totalCoursePosition sub commands = Seq.fold moveWithPosition sub commands |> subTotal
    let totalCourseAim sub commands = Seq.fold moveWithAim sub commands |> subTotal
