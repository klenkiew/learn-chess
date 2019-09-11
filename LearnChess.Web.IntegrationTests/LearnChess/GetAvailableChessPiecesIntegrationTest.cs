using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Web.Controllers.Responses;
using NUnit.Framework;

namespace LearnChess.Web.IntegrationTests.LearnChess
{
    public class GetAvailableChessPiecesIntegrationTest : IntegrationTestBase
    {
        private const string Url = "api/learnChess/availableChessPieces";

        [Test]
        public async Task ShouldReturnProperAvailablePieces()
        {
            var result = await Get<IEnumerable<ChessPieceInfo>>(Url);

            var expectedPieces = new[]
            {
                ChessPieceKind.Knight, ChessPieceKind.Rook, ChessPieceKind.Queen,
            };
            Assert.That(result.Select(p => p.Id), Is.EquivalentTo(expectedPieces));
        }
    }
}