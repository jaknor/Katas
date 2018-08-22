namespace BowlingKata
{
    public class Game
    {
        private int _score;

        public Game()
        {
            _score = 0;
        }

        public int Score()
        {
            return _score;
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            if (numberOfPinsKnockedDown > 0 && numberOfPinsKnockedDown < 10)
            {
                _score += numberOfPinsKnockedDown;
            }
        }
    }
}