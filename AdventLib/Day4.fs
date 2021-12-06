namespace AdventLib

open System.Text.RegularExpressions

module Day4 = 
    type BingoCell = int*bool
    type BingoCard = BingoCell[,]

    let cellIsMarked = function (_, true) -> true | _ -> false

    let checkCard (card:BingoCard) = 
        let sliceIsMarked = Array.forall cellIsMarked
        let length = card.GetLength(0)
        seq 
            { 
                for i in 0..length-1 do
                    yield card.[i, *] |> sliceIsMarked
                    yield card.[*, i] |> sliceIsMarked
            }

    let checkForBingo (card:BingoCard) = 
        card 
        |> checkCard 
        |> Seq.contains true
    
    let markCard (value:int, card:BingoCard) =
        let length = card.GetLength(0)
        for y in 0..length-1 do
            for x in 0..length-1 do
                if (card[x,y] = (value, false)) then
                    card[x,y] <- (value, true)

    let winningScore (card:BingoCard, value:int) =
        let unmarkedSum =
            card 
            |> Seq.cast<int*bool> 
            |> Seq.filter (fun x -> snd x = false) 
            |> Seq.map fst
            |> Seq.sum

        unmarkedSum * value

    let rec play (numbers:List<int>, index:int, card:BingoCard) =
        let value = numbers[index]
        markCard(value, card)
        match checkForBingo card with
        | true -> (winningScore(card,value), index)
        | false -> play (numbers, index+1, card)

    let playBingo (lines: List<string>) =
        let numbers = lines[0].Split ',' |> Array.map int |> Array.toList
        let parseCardLine (line:string) =
            Regex.Split(line.Trim(), "\s+")
            |> Array.map (fun s -> (int s, false))
            |> Array.toList 

        let cards = 
            lines
            |> List.skip 2
            |> List.filter (fun l -> l <> "")
            |> List.map parseCardLine
            |> List.chunkBySize 5
            |> List.map array2D

        let winningCardsInOrder = 
            cards
            |> List.map (fun c -> play(numbers, 0, c))
            |> List.sortBy snd
            |> List.map fst

        (List.head winningCardsInOrder, List.last winningCardsInOrder)
