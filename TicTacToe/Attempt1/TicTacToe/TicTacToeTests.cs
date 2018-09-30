namespace TicTacToe
{
    using Xunit;

    public class TicTacToeTests
    {
        private readonly Board _board;

        public TicTacToeTests()
        {
            _board = new Board();
        }

        [Fact]
        public void PlaceXInTopLeftCorner()
        {
            _board.Place(new Piece('X'), Position.TopLeft);

            Assert.Equal("XEEEEEEEE", _board.ToString());
        }

        [Fact]
        public void CannotPlaceXAfterX()
        {
            _board.Place(new Piece('X'), Position.TopLeft);
            _board.Place(new Piece('X'), Position.TopMiddle);

            Assert.Equal("XEEEEEEEE", _board.ToString());
        }

        [Fact]
        public void CannotPlacePieceOnTopOfOtherPiece()
        {
            _board.Place(new Piece('X'), Position.TopLeft);
            _board.Place(new Piece('O'), Position.TopLeft);

            Assert.Equal("XEEEEEEEE", _board.ToString());
        }

        [Fact]
        public void PlaceONextToX()
        {
            _board.Place(new Piece('X'), Position.TopLeft);
            _board.Place(new Piece('O'), Position.TopMiddle);

            Assert.Equal("XOEEEEEEE", _board.ToString());
        }

        [Fact]
        public void StartWithXInMiddle()
        {
            _board.Place(new Piece('X'), Position.MiddleMiddle);

            Assert.Equal("EEEEXEEEE", _board.ToString());
        }

        [Fact]
        public void HaveToStartWithX()
        {
            _board.Place(new Piece('O'), Position.TopLeft);

            Assert.Equal("EEEEEEEEE", _board.ToString());
        }
    }
}
