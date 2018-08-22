using System;
using Xunit;

namespace BowlingKata
{
    public class GameTests
    {
        [Fact]
        public void NewGameInitialised()
        {
            var game = new Game();

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void RollAndHitOnePin()
        {
            var game = new Game();

            game.Roll(1);

            Assert.Equal(1, game.Score());
        }
    }
}
