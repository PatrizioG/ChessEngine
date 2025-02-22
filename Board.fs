namespace ChessEngine

open Core
open System
open System.Text

module Board =

    type Board = { PiecePositions: array<uint64> }

    let loadFen (fen: string) =
        //https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
        let startPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
        let splitted = startPosition.Split " "

        if splitted.Length <> 6 then
            None
        else
            Some { PiecePositions = [| 1UL; 2UL; 4UL |] }

    let private convertToBitArray number =
        [| for x in 0..63 do
               (number &&& (1UL <<< x)) <> 0UL |]

    let private pieceTypeToChar pieceType printableType =
        //https://en.wikipedia.org/wiki/Chess_symbols_in_Unicode
        //https://en.wikipedia.org/wiki/Algebraic_notation_(chess)
        match pieceType with
        | White, Rook when printableType = Unicode -> '♖'
        | White, Rook when printableType = It -> 'T'
        | White, Rook when printableType = En -> 'R'
        | White, Knight when printableType = Unicode -> '♘'
        | White, Knight when printableType = It -> 'C'
        | White, Knight when printableType = En -> 'N'
        | White, Bishop when printableType = Unicode -> '♗'
        | White, Bishop when printableType = It -> 'A'
        | White, Bishop when printableType = En -> 'B'
        | White, Queen when printableType = Unicode -> '♕'
        | White, Queen when printableType = It -> 'D'
        | White, Queen when printableType = En -> 'Q'
        | White, King when printableType = Unicode -> '♔'
        | White, King when printableType = It -> 'R'
        | White, King when printableType = En -> 'K'
        | White, Pawn when printableType = Unicode -> '♙'
        | White, Pawn when printableType = It -> '♙'
        | White, Pawn when printableType = En -> '♙'
        | Black, Rook when printableType = Unicode -> '♜'
        | Black, Rook when printableType = It -> '♜'
        | Black, Rook when printableType = En -> '♜'
        | Black, Knight when printableType = Unicode -> '♞'
        | Black, Knight when printableType = It -> '♞'
        | Black, Knight when printableType = En -> '♞'
        | Black, Bishop when printableType = Unicode -> '♝'
        | Black, Bishop when printableType = It -> '♝'
        | Black, Bishop when printableType = En -> '♝'
        | Black, Queen when printableType = Unicode -> '♛'
        | Black, Queen when printableType = It -> '♛'
        | Black, Queen when printableType = En -> '♛'
        | Black, King when printableType = Unicode -> '♚'
        | Black, King when printableType = It -> '♚'
        | Black, King when printableType = En -> '♚'
        | Black, Pawn when printableType = Unicode -> '♟'
        | Black, Pawn when printableType = It -> '♟'
        | Black, Pawn when printableType = En -> '♟'

    let private pieceTypeToIdx pieceType =
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

    let private idxToPieceType idx =
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

    let createPrintableChessboard (board: Board) =
        let chessboard =
            [| for x in 0..63 do
                   '*' |]

        for i = 0 to board.PiecePositions.Length - 1 do
            let bitArray = convertToBitArray board.PiecePositions[i]

            let pieceChar =
                match idxToPieceType i with
                | Some pieceType -> pieceTypeToChar pieceType Unicode
                | None -> 'X' // Error

            for i = 0 to bitArray.Length - 1 do
                if bitArray[i] = true then
                    chessboard[i] <- pieceChar

        chessboard
