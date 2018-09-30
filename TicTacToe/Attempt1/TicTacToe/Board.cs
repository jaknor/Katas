namespace TicTacToe
{
    public class Board
    {
        private readonly Pieces _pieces;
        private bool _firstMove;

        public Board()
        {
            _pieces = new Pieces();
            _firstMove = true;
        }

        public void Place(Piece piece, Position position)
        {
            if (_firstMove && piece.CannotBeFirstMove())
            {
                return;
            }

            _pieces.PlacePiece(piece, position);
            _firstMove = false;
        }

        public override string ToString()
        {
            return _pieces.ToString();
        }
    }
}