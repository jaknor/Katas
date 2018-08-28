namespace SnookerScoreboard
{
    class MissedAllBalls : IFoul
    {
        private readonly Ball _nominated;
        private readonly Ball? _hit;

        public MissedAllBalls(Ball nominated, Ball? hit)
        {
            _nominated = nominated;
            _hit = hit;
        }

        public int Penalty()
        {
            return ((int)_nominated) >= 4 ? (int)_nominated : 4;
        }

        public bool Commited()
        {
            return _hit == null;
        }
    }
}