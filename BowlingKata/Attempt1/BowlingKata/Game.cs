namespace BowlingKata
{
    public class Game
    {
        private readonly Frames _frames;
        private Frame _currentFrame;

        public Game()
        {
            _frames = new Frames();
            _currentFrame = new Frame();
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            if (numberOfPinsKnockedDown >= 0 && numberOfPinsKnockedDown <= 10)
            {
                _currentFrame.Score(numberOfPinsKnockedDown);

                if (_currentFrame.Complete())
                {
                    _frames.Add(_currentFrame);
                    _currentFrame = new Frame();
                }
            }
        }

        public int Score()
        {
            return _frames.Score();
        }
    }
}