namespace LearnChess.Application.Domain
{
    internal class ChessMove
    {
        public ChessboardPosition From { get; }
        public ChessboardPosition To { get; }

        public ChessMove(ChessboardPosition from, ChessboardPosition to)
        {
            From = from;
            To = to;
        }
        
        #region Equals & GetHashCode

        protected bool Equals(ChessMove other)
        {
            return From.Equals(other.From) && To.Equals(other.To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChessMove) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (From.GetHashCode() * 397) ^ To.GetHashCode();
            }
        }
        #endregion
    }
}