using System.Collections.Generic;
using LearnChess.Application.Domain.Moves;
using LearnChess.Application.Exceptions;

namespace LearnChess.Application.Domain
{
    public class ChessPieceCollection
    {
        private readonly IReadOnlyDictionary<ChessPieceKind, ChessPiece> pieceDefinitions
            = new Dictionary<ChessPieceKind, ChessPiece>
            {
                [ChessPieceKind.Knight] = new ChessPiece(new KnightMoveSpecification()),
                [ChessPieceKind.Rook] = new ChessPiece(new RookMoveSpecification()),
                [ChessPieceKind.Queen] = new ChessPiece(
                    new CompositeMoveSpecification(
                        new RookMoveSpecification(), 
                        new BishopMoveSpecification())
                    )
            };

        internal ChessPiece GetChessPiece(ChessPieceKind chessPieceKind)
        {
            return pieceDefinitions.TryGetValue(chessPieceKind, out var chessPiece)
                ? chessPiece
                : throw new DomainConstraintViolationException(
                    $"No piece definition found for the following piece kind: {chessPieceKind}");
        }

        internal IEnumerable<ChessPieceKind> GetAvailableChessPieces()
        {
            return pieceDefinitions.Keys;
        }
    }
}