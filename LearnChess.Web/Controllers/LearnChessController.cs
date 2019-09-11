using System.Collections.Generic;
using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers;
using LearnChess.Application.Handlers.GetAvailableChessPieces;
using LearnChess.Application.Handlers.GetChessPiecePossibleMoves;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using LearnChess.Web.Controllers.Responses;
using LearnChess.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnChess.Web.Controllers
{
    [Route("api/[controller]")]
    public class LearnChessController
    {
        private readonly IMediator mediator;
        private readonly ChessPiecesViewInfoSource chessPiecesViewInfoSource;

        public LearnChessController(IMediator mediator, ChessPiecesViewInfoSource chessPiecesViewInfoSource)
        {
            this.mediator = mediator;
            this.chessPiecesViewInfoSource = chessPiecesViewInfoSource;
        }

        [HttpGet("availableChessPieces")]
        public async Task<IEnumerable<ChessPieceInfo>> GetAvailableChessPieces()
        {
            var chessPieces = (await mediator.Send(new GetAvailableChessPiecesRequest())).Pieces;
            return chessPiecesViewInfoSource.GetViewInfoForPieces(chessPieces);
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