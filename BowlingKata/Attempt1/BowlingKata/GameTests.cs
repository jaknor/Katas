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
    }
}
