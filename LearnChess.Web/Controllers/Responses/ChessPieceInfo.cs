using LearnChess.Application.Domain;

namespace LearnChess.Web.Controllers.Responses
{
    public class ChessPieceInfo
    {
        public ChessPieceKind Id { get; }
        public string Label { get; }
        public string Unicode { get; }

        public ChessPieceInfo(ChessPieceKind id, string label, string unicode)
        {
            this.Id = id;
            this.Label = label;
            this.Unicode = unicode;
        }
    }
}