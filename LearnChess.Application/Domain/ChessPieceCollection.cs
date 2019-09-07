using System.Collections.Generic;
using LearnChess.Abstractions.Domain.Exceptions;
using LearnChess.Application.Domain.Moves;

namespace LearnChess.Application.Domain
{
    internal class ChessPieceCollection
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

        public ChessPiece GetChessPiece(ChessPieceKind chessPieceKind)
        {
            return pieceDefinitions.TryGetValue(chessPieceKind, out var chessPiece)
                ? chessPiece
                : throw new DomainConstraintViolationException(
                    $"No piece definition found for the following piece kind: {chessPieceKind}");
        }

        public IEnumerable<ChessPieceKind> GetAvailableChessPieces()
        {
            return pieceDefinitions.Keys;
        }
    }
}