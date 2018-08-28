namespace SnookerScoreboard
{
    using System.Collections.Generic;
    using System.Linq;

    public class WhitePotted : IFoul
    {
        private readonly List<Ball> _potted;

        public WhitePotted(List<Ball> potted)
        {
            _potted = potted;
        }

        public int Penalty()
        {
            return 4;
        }

        public bool Commited()
        {
            return _potted?.Any(p => p == Ball.White) ?? false;
        }
    }
}