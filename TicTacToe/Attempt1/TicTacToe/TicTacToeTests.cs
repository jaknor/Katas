namespace TicTacToe
{
    using Xunit;

    public class TicTacToeTests
    {
        [Fact]
        public void PlaceXInTopLeftCorner()
        {
            var board = new Board();

            board.Place(new Piece("X"), Position.TopLeft);

            Assert.Equal("XEEEEEEEE", board.ToString());
        }

        [Fact]
        public void CannotPlaceXAfterX()
        {
            var board = new Board();

            board.Place(new Piece("X"), Position.TopLeft);
            board.Place(new Piece("X"), Position.TopLeft);

            Assert.Equal("XEEEEEEEE", board.ToString());
        }

        [Fact]
        public void CannotPlacePieceOnTopOfOtherPiece()
        {
            var board = new Board();

            board.Place(new Piece("X"), Position.TopLeft);
            board.Place(new Piece("O"), Position.TopLeft);

            Assert.Equal("XEEEEEEEE", board.ToString());
        }

        [Fact]
        public void PlaceONextToX()
        {
            var board = new Board();

            board.Place(new Piece("X"), Position.TopLeft);
            board.Place(new Piece("O"), Position.TopMiddle);

            Assert.Equal("XOEEEEEEE", board.ToString());
        }
    }
}
