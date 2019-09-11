using LearnChess.Application.Exceptions;

namespace LearnChess.Application.Domain
{
    internal class ChessboardPosition
    {
        public int X { get; }
        public int Y { get; }

        public ChessboardPosition(int x, int y)
        {
            ValidatePosition(x, y);
            X = x;
            Y = y;
        }

        private static void ValidatePosition(int x, int y)
        {
            if (!IsValidPosition(x, y))
            {
                throw new DomainConstraintViolationException(
                    $"Position [{x}, {y}] is not a valid chessboard position.");
            }
        }

        public static bool IsValidPosition(int x, int y)
        {
            return IsValidPosition(x) && IsValidPosition(y);
        }

        private static bool IsValidPosition(int index)
        {
            return index >= 0 && index <= 7;
        }

        public ChessboardPosition MovedBy(PositionChange positionChange)
        {
            if (!CanMoveBy(positionChange))
            {
                throw new DomainConstraintViolationException(
                    $"A move by [{positionChange.X}, {positionChange.Y}] is not allowed from the position [{X}, {Y}");
            }
            return new ChessboardPosition(X + positionChange.X, Y + positionChange.Y);
        }
        
        public bool CanMoveBy(PositionChange positionChange)
        {
            return IsValidPosition(X + positionChange.X, Y + positionChange.Y);
        }

        // TODO Consider creating a base class for value types with compare by value semantics.
        #region Equals & GetHashCode
        
        protected bool Equals(ChessboardPosition other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChessboardPosition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
        #endregion
    }
}