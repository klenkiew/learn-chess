using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers.GetAvailableChessPieces;
using NUnit.Framework;

namespace LearnChess.Web.IntegrationTests.LearnChess
{
    public class GetAvailableChessPiecesIntegrationTest : IntegrationTestBase
    {
        [Test]
        public async Task ShouldReturnProperAvailablePieces()
        {
            var result = await Get<GetAvailableChessPiecesResponse>("learnChess/availableChessPieces");

            var expectedPieces = new[]
            {
                ChessPieceKind.Knight, ChessPieceKind.Rook, ChessPieceKind.Queen,
            };
            Assert.That(result.Pieces, Is.EquivalentTo(expectedPieces));
        }
    }
}