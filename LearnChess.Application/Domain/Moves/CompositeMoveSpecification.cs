using System.Collections.Generic;
using System.Linq;

namespace LearnChess.Application.Domain.Moves
{
    internal class CompositeMoveSpecification : IChessMoveTypeSpecification
    {
        private readonly IEnumerable<IChessMoveTypeSpecification> components;

        public CompositeMoveSpecification(IEnumerable<IChessMoveTypeSpecification> components)
        {
            this.components = components;
        }
        
        public CompositeMoveSpecification(params IChessMoveTypeSpecification[] components)
        {
            this.components = components;
        }

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return components.SelectMany(moveType => moveType.GetPossibleMoves(currentPosition)).Distinct();
        }
    }
}