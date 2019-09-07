using System.Threading.Tasks;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using NUnit.Framework;

namespace LearnChess.Web.IntegrationTests.LearnChess
{
    public class ValidateMoveIntegrationTest : IntegrationTestBase
    {
        [Test]
        public async Task TestForValidMove()
        {
            var request = new ValidateChessPieceMoveRequest(
                ChessPieceKind.Knight, new ChessboardPositionDto(4, 4), new ChessboardPositionDto(6, 5));
            
            var result = await Post<ValidateChessPieceMoveResponse>("learnChess/validateMove", request);

            Assert.That(result, Is.EqualTo(ValidateChessPieceMoveResponse.ValidMove));
        }
        
        [Test]
        public async Task TestForInvalidMove()
        {
            var request = new ValidateChessPieceMoveRequest(
                ChessPieceKind.Knight, new ChessboardPositionDto(4, 4), new ChessboardPositionDto(6, 4));
            
            var result = await Post<ValidateChessPieceMoveResponse>("learnChess/validateMove", request);

            Assert.That(result, Is.EqualTo(ValidateChessPieceMoveResponse.InvalidMove));
        }
    }
}