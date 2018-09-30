namespace TicTacToe
{
    using Xunit;

    public class TicTacToeTests
    {
        [Fact]
        public void PlaceXInTopLeftCorner()
        {
            var board = new Board();

            board.Place(new Piece("X"));

            Assert.Equal(board.ToString(),"XEEEEEEEE");
        }

        [Fact]
        public void CannotPlaceXAfterX()
        {
            var board = new Board();

            board.Place(new Piece("X"));
            board.Place(new Piece("X"));

            Assert.Equal(board.ToString(), "XEEEEEEEE");
        }

        [Fact]
        public void CannotPlacePieceOnTopOfOtherPiece()
        {
            var board = new Board();

            board.Place(new Piece("X"));
            board.Place(new Piece("O"));

            Assert.Equal(board.ToString(), "XEEEEEEEE");
        }
    }
}
