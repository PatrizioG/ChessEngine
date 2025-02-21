namespace ChessEngine

open Core
open System.Text

module Board =
    type Board = { PiecePositions: array<uint64> }

    let print (board: Board) : string =
        let sb = new StringBuilder()
        let res = board.PiecePositions |> Array.fold (fun acc v -> acc + v) 0UL

        for i = 0 to board.PiecePositions.Length do
            sb.Append("") |> ignore

        sb.ToString()

    let private PieceTypeToPrintable pieceType printableType =
        //https://en.wikipedia.org/wiki/Chess_symbols_in_Unicode
        //https://en.wikipedia.org/wiki/Algebraic_notation_(chess)
        match pieceType with
        | White, Rook when printableType = Unicode -> "♖"
        | White, Rook when printableType = It -> "T"
        | White, Rook when printableType = En -> "R"
        | White, Knight when printableType = Unicode -> "♘"
        | White, Knight when printableType = It -> "C"
        | White, Knight when printableType = En -> "N"
        | White, Bishop when printableType = Unicode -> "♗"
        | White, Bishop when printableType = It -> "A"
        | White, Bishop when printableType = En -> "B"
        | White, Queen when printableType = Unicode -> "♕"
        | White, Queen when printableType = It -> "D"
        | White, Queen when printableType = En -> "Q"
        | White, King when printableType = Unicode -> "♔"
        | White, King when printableType = It -> "R"
        | White, King when printableType = En -> "K"
        | White, Pawn when printableType = Unicode -> "♙"
        | White, Pawn when printableType = It -> "♙"
        | White, Pawn when printableType = En -> "♙"
        | Black, Rook -> "♜"
        | Black, Knight -> "♞"
        | Black, Bishop -> "♝"
        | Black, Queen -> "♛"
        | Black, King -> "♚"
        | Black, Pawn -> "♟"

    let private PieceTypeToIdx pieceType =
        match pieceType with
        | White, Rook -> 0
        | White, Knight -> 1
        | White, Bishop -> 2
        | White, Queen -> 3
        | White, King -> 4
        | White, Pawn -> 5
        | Black, Rook -> 6
        | Black, Knight -> 7
        | Black, Bishop -> 8
        | Black, Queen -> 9
        | Black, King -> 10
        | Black, Pawn -> 11

    let private IdxtoPieceType idx =
        match idx with
        | 0 -> Some(White, Rook)
        | 1 -> Some(White, Knight)
        | 2 -> Some(White, Bishop)
        | 3 -> Some(White, Queen)
        | 4 -> Some(White, King)
        | 5 -> Some(White, Pawn)
        | 6 -> Some(Black, Rook)
        | 7 -> Some(Black, Knight)
        | 8 -> Some(Black, Bishop)
        | 9 -> Some(Black, Queen)
        | 10 -> Some(Black, King)
        | 11 -> Some(Black, Pawn)
        | _ -> None
