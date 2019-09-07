using LearnChess.Application.Domain;
using MediatR;

namespace LearnChess.Application.Handlers.ValidateChessPieceMove
{
    public class ValidateChessPieceMoveRequest : IRequest<ValidateChessPieceMoveResponse>
    {
        public ChessPieceKind ChessPieceKind { get; }
        public ChessboardPositionDto CurrentPosition { get; }
        public ChessboardPositionDto TargetPosition { get; }

        public ValidateChessPieceMoveRequest(
            ChessPieceKind chessPieceKind, ChessboardPositionDto currentPosition, ChessboardPositionDto targetPosition)
        {
            ChessPieceKind = chessPieceKind;
            CurrentPosition = currentPosition;
            TargetPosition = targetPosition;
        }
    }
}