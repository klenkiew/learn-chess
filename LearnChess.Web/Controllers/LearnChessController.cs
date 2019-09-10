using System.Collections.Generic;
using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers;
using LearnChess.Application.Handlers.GetAvailableChessPieces;
using LearnChess.Application.Handlers.GetChessPiecePossibleMoves;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using LearnChess.Web.Controllers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnChess.Web.Controllers
{
    [Route("api/[controller]")]
    public class LearnChessController
    {
        private readonly IMediator mediator;
        private readonly ChessPiecesViewInfoProvider chessPiecesViewInfoProvider;

        public LearnChessController(IMediator mediator, ChessPiecesViewInfoProvider chessPiecesViewInfoProvider)
        {
            this.mediator = mediator;
            this.chessPiecesViewInfoProvider = chessPiecesViewInfoProvider;
        }

        [HttpGet("availableChessPieces")]
        public async Task<IEnumerable<ChessPieceInfo>> GetAvailableChessPieces()
        {
            return chessPiecesViewInfoProvider.GetViewInfoForPieces((
                await mediator.Send(new GetAvailableChessPiecesRequest())).Pieces);
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