using System.Collections.Generic;
using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers;
using LearnChess.Application.Handlers.GetChessPiecePossibleMoves;
using NUnit.Framework;

namespace LearnChess.Web.IntegrationTests.LearnChess
{
    public class GetChessPiecePossibleMovesIntegrationTest : IntegrationTestBase
    {
        private const string Url = "api/learnChess/availableMoves";

        [Test]
        public async Task ShouldReturnProperMoves()
        {
            var queryParams = new Dictionary<string, string>
            {
                ["currentX"] = "4",
                ["currentY"] = "4",
                ["chessPieceKind"] = ChessPieceKind.Knight.ToString(),
            };
            
            var result = await Get<GetChessPiecePossibleMovesResponse>(Url, queryParams);

            Assert.That(result.CurrentPosition, Is.EqualTo(new ChessboardPositionDto(4, 4)));
            Assert.That(result.PossibleMoves, Has.One.EqualTo(new ChessboardPositionDto(6, 5)));
        }
    }
}