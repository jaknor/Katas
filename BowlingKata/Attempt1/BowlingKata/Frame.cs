namespace BowlingKata
{
    public class Frame
    {
        private int _firstScore;
        private int _secondScore;
        private bool _firstAttempt;
        private bool _complete;

        public Frame()
        {
            _firstAttempt = true;
        }

        public void Score(int numberOfPinsKnockedDown)
        {
            if (_firstAttempt)
            {
                _firstScore = numberOfPinsKnockedDown;
                _firstAttempt = false;
                _complete = _firstScore == 10;
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
            return _firstScore == 10;
        }

        public bool WasSpare()
        {
            return _firstScore < 10 && _firstScore + _secondScore == 10;
        }

        public bool Complete()
        {
            return _complete;
        }
    }
}