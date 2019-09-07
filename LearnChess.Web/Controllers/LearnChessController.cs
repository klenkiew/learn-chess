using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers;
using LearnChess.Application.Handlers.GetAvailableChessPieces;
using LearnChess.Application.Handlers.GetChessPiecePossibleMoves;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnChess.Web.Controllers
{
    [Route("[controller]")]
    public class LearnChessController
    {
        private readonly IMediator mediator;

        public LearnChessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("availableChessPieces")]
        public async Task<GetAvailableChessPiecesResponse> GetAvailableChessPieces()
        {
            return await mediator.Send(new GetAvailableChessPiecesRequest());
        }
        
        [HttpGet("availableMoves")]
        public async Task<GetChessPiecePossibleMovesResponse> GetAvailableMoves(
            int currentX, int currentY, ChessPieceKind chessPieceKind)
        {
            var request = new GetChessPiecePossibleMovesRequest(
                new ChessboardPositionDto(currentX, currentY), chessPieceKind);
            return await mediator.Send(request);
        }
        
        [HttpPost("validateMove")]
        public async Task<ValidateChessPieceMoveResponse> ValidateMove([FromBody] ValidateChessPieceMoveRequest request)
        {
            return await mediator.Send(request);
        }
    }
}