namespace TicTacToe
{
    public class Board
    {
        private readonly Pieces _pieces;

        public Board()
        {
            _pieces = new Pieces();
        }

        public void Place(Piece piece, Position position)
        {
            _pieces.PlacePiece(piece, position);
        }

        public override string ToString()
        {
            return _pieces.ToString();
        }
    }
}