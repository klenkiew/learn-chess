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
    }
}