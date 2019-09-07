using System.Threading;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers.GetAvailableChessPieces;
using MediatR;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Handlers.GetAvailableChessPieces
{
    internal class AvailableChessPiecesTest
    {
        [Test]
        public void TestAvailableChessPieces()
        {
            var availableChessPiecesResponse = HandleRequest(new GetAvailableChessPiecesRequest());
            var expectedAvailablePieces = new[]
            {
                ChessPieceKind.Queen, ChessPieceKind.Knight, ChessPieceKind.Rook
            };
            Assert.That(availableChessPiecesResponse.Pieces, Is.EquivalentTo(expectedAvailablePieces));
        }
        
        private static GetAvailableChessPiecesResponse HandleRequest(GetAvailableChessPiecesRequest request)
        {
            var handler = CreateHandler();
            return handler.Handle(request, CancellationToken.None).Result;
        }

        private static IRequestHandler<GetAvailableChessPiecesRequest, GetAvailableChessPiecesResponse> 
            CreateHandler()
        {
            var handler = new GetAvailableChessPiecesRequestHandler(new ChessPieceCollection());
            return handler;
        }
    }
}