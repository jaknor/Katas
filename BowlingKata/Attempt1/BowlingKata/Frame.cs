namespace BowlingKata
{
    public class Frame
    {
        private const int TotalNumberOfPins = 10;

        private int _firstScore;
        private int _secondScore;
        private bool _isFirstAttempt;
        private bool _complete;
        private Frame _next;
        public Frame()
        {
            _isFirstAttempt = true;
        }

        public void Score(int numberOfPinsKnockedDown)
        {
            if (_isFirstAttempt)
            {
                _firstScore = numberOfPinsKnockedDown;
                _isFirstAttempt = false;
                _complete = _firstScore == TotalNumberOfPins;
            }
            else
            {
                _secondScore = numberOfPinsKnockedDown;
                _complete = true;
            }

        }

        internal int Score()
        {
            return _firstScore + _secondScore;
        }

        internal int ScoreOfFirstThrow()
        {
            return _firstScore;
        }

        public bool WasStrike()
        {
            return _firstScore == TotalNumberOfPins;
        }

        public bool WasSpare()
        {
            return _firstScore < TotalNumberOfPins && _firstScore + _secondScore == TotalNumberOfPins;
        }

        public bool Complete()
        {
            return _complete;
        }
    }
}