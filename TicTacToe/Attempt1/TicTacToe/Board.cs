namespace TicTacToe
{
    public class Board
    {
        private readonly Pieces _pieces;
        private Piece _lastPiece;

        public Board()
        {
            _pieces = new Pieces();
        }

        public void Place(Piece piece, Position position)
        {
            if (FirstMove(_lastPiece) && piece.CannotBeFirstMove() || SamePieceAsLastMove(piece))
            {
                return;
            }

            _pieces.PlacePiece(piece, position);
            _lastPiece = piece;
        }

        public override string ToString()
        {
            return _pieces.ToString();
        }

        private bool FirstMove(Piece lastPiece)
        {
            return lastPiece == null;
        }

        private bool SamePieceAsLastMove(Piece piece)
        {
            return _lastPiece?.Equals(piece) ?? false;
        }
    }
}