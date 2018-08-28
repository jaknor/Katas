namespace SnookerScoreboard
{
    class WrongBallPotted : IFoul
    {
        private readonly Ball _nominated;
        private readonly Ball _potted;

        public WrongBallPotted(Ball nominated, Ball potted)
        {
            _nominated = nominated;
            _potted = potted;
        }

        public int Penalty()
        {
            return (int)_potted >= 4 ? (int)_potted : 4;
        }

        public bool Commited()
        {
            return _potted != _nominated;
        }
    }
}