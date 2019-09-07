using LearnChess.Application.Domain;
using MediatR;

namespace LearnChess.Application.Handlers.ValidateChessPieceMove
{
    internal class ValidateChessPieceMoveHandler 
        : RequestHandler<ValidateChessPieceMoveRequest, ValidateChessPieceMoveResponse>
    {
        private readonly ChessPieceCollection chessPieceCollection;

        public ValidateChessPieceMoveHandler(ChessPieceCollection chessPieceCollection)
        {
            this.chessPieceCollection = chessPieceCollection;
        }

        protected override ValidateChessPieceMoveResponse Handle(ValidateChessPieceMoveRequest request)
        {
            var isMoveAllowed = chessPieceCollection.GetChessPiece(request.ChessPieceKind).IsMoveAllowed(
                new ChessboardPosition(request.CurrentPosition.X, request.CurrentPosition.Y),
                new ChessboardPosition(request.TargetPosition.X, request.TargetPosition.Y));
            return isMoveAllowed
                ? ValidateChessPieceMoveResponse.ValidMove
                : ValidateChessPieceMoveResponse.InvalidMove;
        }
    }
}