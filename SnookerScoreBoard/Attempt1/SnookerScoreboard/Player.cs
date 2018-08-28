namespace SnookerScoreboard
{
    class Player
    {
        private int _score;
        private int _break;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Score => _score;

        public void IncreaseScore(int score)
        {
            _score += score;
            _break += score;
        }

        public int Break()
        {
            return _break;
        }

        public void ResetBreak()
        {
            _break = 0;
        }
    }
}