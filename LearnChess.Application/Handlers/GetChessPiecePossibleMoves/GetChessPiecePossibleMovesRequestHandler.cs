using System.Linq;
using LearnChess.Application.Domain;
using MediatR;

namespace LearnChess.Application.Handlers.GetChessPiecePossibleMoves
{
    internal class GetChessPiecePossibleMovesRequestHandler 
        : RequestHandler<GetChessPiecePossibleMovesRequest, GetChessPiecePossibleMovesResponse>
    {
        private readonly ChessPieceCollection chessPieceCollection;

        public GetChessPiecePossibleMovesRequestHandler(ChessPieceCollection chessPieceCollection)
        {
            this.chessPieceCollection = chessPieceCollection;
        }

        protected override GetChessPiecePossibleMovesResponse Handle(GetChessPiecePossibleMovesRequest request)
        {
            var currentPosition = new ChessboardPosition(request.ChessboardPosition.X, request.ChessboardPosition.Y);
            var possibleMoves = chessPieceCollection
                .GetChessPiece(request.ChessPieceKind)
                .GetPossibleMoves(currentPosition);
            return new GetChessPiecePossibleMovesResponse(
                request.ChessboardPosition,
                possibleMoves.Select(m => new ChessboardPositionDto(m.To.X, m.To.Y)));
        }
    }
}