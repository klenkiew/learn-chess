using System.Collections.Generic;
using LearnChess.Application.Domain;

namespace LearnChess.Application.Handlers.GetAvailableChessPieces
{
    public class GetAvailableChessPiecesResponse
    {
        public IEnumerable<ChessPieceKind> Pieces { get; }

        public GetAvailableChessPiecesResponse(IEnumerable<ChessPieceKind> pieces)
        {
            Pieces = pieces;
        }
    }
}