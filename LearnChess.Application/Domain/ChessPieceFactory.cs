using System.Collections.Generic;
using LearnChess.Abstractions.Domain.Exceptions;
using LearnChess.Application.Domain.Moves;

namespace LearnChess.Application.Domain
{
    internal class ChessPieceFactory
    {
        private readonly IReadOnlyDictionary<ChessPieceKind, ICollection<IChessMoveTypeSpecification>> pieceDefinitions
            = new Dictionary<ChessPieceKind, ICollection<IChessMoveTypeSpecification>>
            {
                [ChessPieceKind.Knight] = new[] { new KnightMoveSpecification() },
                [ChessPieceKind.Rook] = new[] { new RookMoveSpecification() },
                [ChessPieceKind.Queen] = new IChessMoveTypeSpecification[]
                {
                    new RookMoveSpecification(), new BishopMoveTypeSpecification(),
                }
            };

        public ChessPiece CreateChessPiece(ChessPieceKind chessPieceKind)
        {
            return new ChessPiece(GetChessPieceMoves(chessPieceKind));
        }

        private ICollection<IChessMoveTypeSpecification> GetChessPieceMoves(ChessPieceKind chessPieceKind)
        {
            return pieceDefinitions.TryGetValue(chessPieceKind, out var pieceMoves)
                ? pieceMoves
                : throw new DomainConstraintViolationException(
                    $"No piece definition found for the following piece kind: {chessPieceKind}");
        }
    }
}