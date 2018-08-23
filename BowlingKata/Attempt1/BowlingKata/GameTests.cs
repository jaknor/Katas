using Xunit;

namespace BowlingKata
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void NewGameInitialised()
        {
            Assert.Equal(0, _game.Score());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void RollAndHitPins(int numberOfPinsKnockedDown)
        {
            _game.Roll(numberOfPinsKnockedDown);

            Assert.Equal(numberOfPinsKnockedDown, _game.Score());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        [InlineData(-100)]
        [InlineData(100)]
        public void RollAndHitInvalidNumberOfPins(int numberOfPinsKnockedDown)
        {
            // Given too many pins in a roll
            _game.Roll(numberOfPinsKnockedDown);

            // The game ignores the roll and does not give any score
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void RollingASingleStrike()
        {
            _game.Roll(10);

            Assert.Equal(10, _game.Score());
        }

        [Fact]
        public void RollingTwoRegularFrames()
        {
            _game.Roll(3);
            _game.Roll(6);
            _game.Roll(2);
            _game.Roll(6);

            Assert.Equal(17, _game.Score());
        }

        [Fact]
        public void RollingAStrikeFollowedByARegularFrame()
        {
            _game.Roll(10);
            _game.Roll(6);
            _game.Roll(2);

            Assert.Equal(26, _game.Score());
        }

        [Fact]
        public void RollingAStrikeFollowedByTwoRegularFrames()
        {
            _game.Roll(10);
            _game.Roll(6);
            _game.Roll(2);
            _game.Roll(3);
            _game.Roll(2);

            Assert.Equal(31, _game.Score());
        }

        [Fact]
        public void RollingASingleSpare()
        {
            _game.Roll(9);
            _game.Roll(1);

            Assert.Equal(10, _game.Score());
        }

        [Fact]
        public void RollingASingleSpareFollowedByARegularFrame()
        {
            _game.Roll(9);
            _game.Roll(1);
            _game.Roll(1);
            _game.Roll(1);

            Assert.Equal(13, _game.Score());
        }

        [Fact]
        public void RollingASingleSpareFollowedByTwoRegularFrames()
        {
            _game.Roll(9);
            _game.Roll(1);
            _game.Roll(1);
            _game.Roll(1);
            _game.Roll(1);
            _game.Roll(1);

            Assert.Equal(15, _game.Score());
        }

        [Fact]
        public void GutterGame()
        {
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            _game.Roll(0);
            

            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void GameWithNoStrikesOrSpares()
        {
            _game.Roll(1);
            _game.Roll(2);
            _game.Roll(3);
            _game.Roll(4);
            _game.Roll(5);
            _game.Roll(4);
            _game.Roll(7);
            _game.Roll(1);
            _game.Roll(9);
            _game.Roll(0);
            _game.Roll(4);
            _game.Roll(4);
            _game.Roll(3);
            _game.Roll(3);
            _game.Roll(2);
            _game.Roll(1);
            _game.Roll(5);
            _game.Roll(2);
            _game.Roll(1);
            _game.Roll(0);


            Assert.Equal(61, _game.Score());
        }
    }
}
