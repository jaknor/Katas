namespace BowlingKata
{
    public class Frame
    {
        private int _numberOfPinsKnockedDown;

        public void Score(int numberOfPinsKnockedDown)
        {
            _numberOfPinsKnockedDown += numberOfPinsKnockedDown;
        }

        internal int Score()
        {
            return _numberOfPinsKnockedDown;
        }

        public bool WasStrike()
        {
            return _numberOfPinsKnockedDown == 10;
        }
    }
}