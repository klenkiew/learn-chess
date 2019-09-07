namespace LearnChess.Application.Domain
{
    internal class PositionChange
    {
        public int X { get; }
        public int Y { get; }

        private PositionChange(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static PositionChange By(int x, int y)
        {
            return new PositionChange(x, y);
        }
    }
}