using LearnChess.Application.Domain;
using MediatR;

namespace LearnChess.Application.Handlers.GetAvailableChessPieces
{
    internal class GetAvailableChessPiecesRequestHandler 
        : RequestHandler<GetAvailableChessPiecesRequest, GetAvailableChessPiecesResponse>
    {
        private readonly ChessPieceCollection chessPieceCollection;

        public GetAvailableChessPiecesRequestHandler(ChessPieceCollection chessPieceCollection)
        {
            this.chessPieceCollection = chessPieceCollection;
        }

        protected override GetAvailableChessPiecesResponse Handle(GetAvailableChessPiecesRequest request)
        {
            return new GetAvailableChessPiecesResponse(chessPieceCollection.GetAvailableChessPieces());
        }
    }
}