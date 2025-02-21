namespace ChessEngine

module Core =

    type Color =
        | White
        | Black

    type Piece =
        | Rook
        | Knight
        | Bishop
        | Queen
        | King
        | Pawn

    type PrintableType =
        | Unicode
        | En
        | It
