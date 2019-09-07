namespace LearnChess.Application.Handlers
{
    public class ChessboardPositionDto
    {
        public int X { get; }
        public int Y { get; }

        public ChessboardPositionDto(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected bool Equals(ChessboardPositionDto other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChessboardPositionDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}