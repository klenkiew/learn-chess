using System;
using System.Collections.Generic;
using System.Linq;
using LearnChess.Application.Domain;
using LearnChess.Web.Controllers.Responses;

namespace LearnChess.Web.Services
{
    public class ChessPiecesViewInfoSource
    {
        private readonly IReadOnlyDictionary<ChessPieceKind, ChessPieceInfo> chessPieceViewData =
            new Dictionary<ChessPieceKind, ChessPieceInfo>()
            {
                [ChessPieceKind.Knight] = new ChessPieceInfo(ChessPieceKind.Knight, "Skoczek", "&#9822;"),
                [ChessPieceKind.Queen] = new ChessPieceInfo(ChessPieceKind.Queen, "Hetman", "&#9819;"),
                [ChessPieceKind.Rook] = new ChessPieceInfo(ChessPieceKind.Rook, "Wieża", "&#9820;"),
                [ChessPieceKind.King] = new ChessPieceInfo(ChessPieceKind.King, "Król", "&#9818;"),
                [ChessPieceKind.Bishop] = new ChessPieceInfo(ChessPieceKind.Bishop, "Goniec", "&#9821;"),
                [ChessPieceKind.Pawn] = new ChessPieceInfo(ChessPieceKind.Pawn, "Pion", "&#9823;")
            };

        public IEnumerable<ChessPieceInfo> GetViewInfoForPieces(IEnumerable<ChessPieceKind> chessPieces)
        {
            return chessPieces.Select(chessPiece =>
            {
                if (!chessPieceViewData.TryGetValue(chessPiece, out var enrichedChessPiece))
                    throw new ArgumentOutOfRangeException(nameof(chessPiece), chessPiece, "Invalid chess piece");
                return enrichedChessPiece;
            });
        }
    }
}