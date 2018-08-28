namespace SnookerScoreboard
{
    public class WrongBallHit : IFoul
    {
        private readonly Ball _nominated;
        private readonly Ball? _ballHit;

        public WrongBallHit(Ball nominated, Ball? ballHit)
        {
            _nominated = nominated;
            _ballHit = ballHit;
        }

        public int Penalty()
        {
            return _ballHit.HasValue && (int)_ballHit.Value >= 4 ? (int)_ballHit : 4;
        }

        public bool Commited()
        {
            return _ballHit != _nominated;
        }
    }
}