namespace SnookerScoreboard
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Abstractions;

    public class FrameTests
    {
        private readonly ITestOutputHelper _output;
        private readonly Frame _frame;

        public FrameTests(ITestOutputHelper output)
        {
            _output = output;
            _frame = new Frame();
        }

        [Fact]
        public void EmptyFrame()
        {
            Assert.Equal("Current Player: Player 1. Score: 0 - 0. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void Player1FirstShotHitsRedButDoesNotPotIt()
        {
            _frame.AddShot(new Shot(Ball.Red, null));

            Assert.Equal("Current Player: Player 2. Score: 0 - 0. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void Player2FirstShotHitsRedButDoesNotPotIt()
        {
            Player1FirstShotHitsRedButDoesNotPotIt();

            _frame.AddShot(new Shot(Ball.Red, null));

            Assert.Equal("Current Player: Player 1. Score: 0 - 0. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void Player1FirstShotHitsRedAndPotIt()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));

            Assert.Equal("Current Player: Player 1. Score: 1 - 0. Break: 1. Remaining Points: 146", _frame.ToString());
        }

        [Fact]
        public void Player2FirstShotHitsRedAndPotIt()
        {
            Player1FirstShotHitsRedButDoesNotPotIt();

            _frame.AddShot(new Shot(Ball.Red, new List<Ball>() { Ball.Red }));

            Assert.Equal("Current Player: Player 2. Score: 0 - 1. Break: 1. Remaining Points: 146", _frame.ToString());
        }

        [Fact]
        public void Player1FirstShotMissesAll()
        {
            _frame.AddShot(new Shot(null, null));

            Assert.Equal("Current Player: Player 2. Score: 0 - 4. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Theory]
        [InlineData(Ball.Yellow)]
        [InlineData(Ball.Green)]
        [InlineData(Ball.Brown)]
        [InlineData(Ball.Blue)]
        [InlineData(Ball.Pink)]
        [InlineData(Ball.Black)]
        public void Player1FirstShotHitsRedAndPotItThenNominateOtherColorAndPotIt(Ball color)
        {
            Player1FirstShotHitsRedAndPotIt();
            
            _frame.AddShot(new Shot(color, new List<Ball> { color }, color));

            var score = (int)color + 1;
            Assert.Equal($"Current Player: Player 1. Score: {score} - 0. Break: {score}. Remaining Points: 139", _frame.ToString());
        }

        [Fact]
        public void Player1FirstShotHitsRedAndPotItThenNominateBlackAndMissIt()
        {
            Player1FirstShotHitsRedAndPotIt();

            _frame.AddShot(new Shot(null, null, Ball.Black));

            Assert.Equal("Current Player: Player 2. Score: 1 - 7. Break: 0. Remaining Points: 139", _frame.ToString());
        }

        [Fact]
        public void Player1FirstShotHitsRedAndPotItThenNominateBlackHitsItButDoesNotPotIt()
        {
            Player1FirstShotHitsRedAndPotIt();

            _frame.AddShot(new Shot(Ball.Black, null, Ball.Black));

            Assert.Equal("Current Player: Player 2. Score: 1 - 0. Break: 0. Remaining Points: 139", _frame.ToString());
        }

        [Fact]
        public void Player1PotWhite()
        {
            _frame.AddShot(new Shot(null, new List<Ball> { Ball.White }));

            Assert.Equal("Current Player: Player 2. Score: 0 - 4. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void Player2PotWhite()
        {
            Player1PotWhite();

            _frame.AddShot(new Shot(null, new List<Ball> { Ball.White }));

            Assert.Equal("Current Player: Player 1. Score: 4 - 4. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Theory]
        [InlineData(Ball.Yellow)]
        [InlineData(Ball.Green)]
        [InlineData(Ball.Brown)]
        [InlineData(Ball.Blue)]
        [InlineData(Ball.Pink)]
        [InlineData(Ball.Black)]
        public void Player1PotsOtherColorInsteadOfRed(Ball colorPotted)
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball>() { colorPotted }));

            var penaltyFromPotted = (int)colorPotted >= 4 ? (int)colorPotted : 4;
            Assert.Equal($"Current Player: Player 2. Score: 0 - {penaltyFromPotted}. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Theory]
        [InlineData(Ball.Yellow)]
        [InlineData(Ball.Green)]
        [InlineData(Ball.Brown)]
        [InlineData(Ball.Blue)]
        [InlineData(Ball.Pink)]
        [InlineData(Ball.Black)]
        public void Player1HitsWrongBall(Ball color)
        {
            _frame.AddShot(new Shot(color, new List<Ball>()));
            
            var penaltyFromHitBall = (int)color >= 4 ? (int)color : 4;
            Assert.Equal($"Current Player: Player 2. Score: 0 - {penaltyFromHitBall}. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void MultipleFouls()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Blue, Ball.Pink, Ball.White }, Ball.Yellow ));

            Assert.Equal($"Current Player: Player 2. Score: 0 - {6}. Break: 0. Remaining Points: 147", _frame.ToString());
        }

        [Fact]
        public void PlayerPotsCorrectBallAndCommitsAFoul()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.White }));

            Assert.Equal($"Current Player: Player 2. Score: 0 - {4}. Break: 0. Remaining Points: 139", _frame.ToString());
        }

        [Fact]
        public void CanPotMultipleReds()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> {Ball.Red, Ball.Red, Ball.Red}));

            Assert.Equal($"Current Player: Player 1. Score: 3 - 0. Break: 3. Remaining Points: 130", _frame.ToString());
        }

        [Fact]
        public void SimpleBreak()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));

            Assert.Equal($"Current Player: Player 1. Score: 9 - 0. Break: 9. Remaining Points: 82", _frame.ToString());
        }

        [Fact]
        public void MediumBreak()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Green, new List<Ball> { Ball.Green }, Ball.Green));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Brown, new List<Ball> { Ball.Brown }, Ball.Brown));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Pink, new List<Ball> { Ball.Pink }, Ball.Pink));
            Assert.Equal($"Current Player: Player 1. Score: 26 - 0. Break: 26. Remaining Points: 99", _frame.ToString());
        }

        [Fact]
        public void BreakForPlayer2()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Green, new List<Ball> { Ball.Green }, Ball.Green));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Brown, new List<Ball> { Ball.Brown }, Ball.Brown));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Pink, new List<Ball> { Ball.Pink }, Ball.Pink));

            _frame.AddShot(new Shot(null, null));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red, Ball.Red, Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Blue, new List<Ball> { Ball.Blue }, Ball.Blue));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Pink, new List<Ball> { Ball.Pink }, Ball.Pink));
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Pink, new List<Ball> { Ball.Pink }, Ball.Pink));
            Assert.Equal($"Current Player: Player 2. Score: 26 - 34. Break: 30. Remaining Points: 51", _frame.ToString());
        }

        [Fact]
        public void AmazingBreak()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red}));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Yellow, new List<Ball> { Ball.Yellow }, Ball.Yellow));
            _frame.AddShot(new Shot(Ball.Green, new List<Ball> { Ball.Green }, Ball.Green));
            _frame.AddShot(new Shot(Ball.Brown, new List<Ball> { Ball.Brown }, Ball.Brown));
            _frame.AddShot(new Shot(Ball.Blue, new List<Ball> { Ball.Blue }, Ball.Blue));
            _frame.AddShot(new Shot(Ball.Pink, new List<Ball> { Ball.Pink }, Ball.Pink));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            Assert.Equal($"Current Player: Player 1. Score: 147 - 0. Break: 147. Remaining Points: 0", _frame.ToString());
        }

        [Fact]
        public void RemainingPointsWithNoReds()
        {
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));
            _frame.AddShot(new Shot(Ball.Black, new List<Ball> { Ball.Black }, Ball.Black));

            Assert.Equal($"Current Player: Player 1. Score: 120 - 0. Break: 120. Remaining Points: 27", _frame.ToString());
        }

        [Fact]
        public void ActualGame()
        {
            _output.WriteLine(_frame.ToString());

            // Player 1 breaks, but does not pocket anything
            _frame.AddShot(new Shot(Ball.Red, new List<Ball>()));

            _output.WriteLine(_frame.ToString());

            // Player 2 pots red (1)
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));

            _output.WriteLine(_frame.ToString());

            // Player 2 pots yellow (2)
            _frame.AddShot(new Shot(Ball.Yellow, new List<Ball> { Ball.Yellow }, Ball.Yellow));

            _output.WriteLine(_frame.ToString());

            // Player 2 pots red (1)
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));

            _output.WriteLine(_frame.ToString());

            // Player 2 hits yellow but does not pot it
            _frame.AddShot(new Shot(Ball.Yellow, new List<Ball>(), Ball.Yellow));

            _output.WriteLine(_frame.ToString());

            // Player 1 pots red
            _frame.AddShot(new Shot(Ball.Red, new List<Ball> { Ball.Red }));

            _output.WriteLine(_frame.ToString());

            // Player 1 pots red and yellow (only yellow should have gone in)
            _frame.AddShot(new Shot(Ball.Yellow, new List<Ball> { Ball.Red, Ball.Yellow }, Ball.Yellow));

            _output.WriteLine(_frame.ToString());

        }
    }
}
