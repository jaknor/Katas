namespace TicTacToe
{
    using System.Linq;

    public class Pieces
    {
        private readonly Piece[] _placedPieces;

        public Pieces()
        {
            _placedPieces = new Piece[9];
            for (int index = 0; index < 9; index++)
            {
                _placedPieces[index] = new Piece("E");
            }
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (_placedPieces[(int)position].IsEmpty())
            {
                _placedPieces[(int)position] = piece;
            }
        }

        public override string ToString()
        {
            return string.Join("", _placedPieces.Select(piece => piece.ToString()));
        }
    }
}