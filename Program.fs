open ChessEngine.Board

[<EntryPoint>]
let main args =
    let board: Board = { PiecePositions = [| 1UL; 2UL; 4UL |] }
    let printable = createPrintableChessboard board

    for i = 0 to 7 do
        for j = 0 to 7 do
            printf "%A" printable[8 * i + j]

        printf "\n"

    System.Console.ReadLine() |> ignore
    0
