namespace SnookerScoreboard
{
    using System.Collections.Generic;
    using System.Linq;

    public class PossibleFouls
    {
        private readonly List<IFoul> _fouls;

        public PossibleFouls(Ball nominated, Ball? ballHit, List<Ball> ballPotted)
        {
            _fouls = new List<IFoul>
            {
                new WhitePotted(ballPotted),
                new MissedAllBalls(nominated, ballHit),
                new WrongBallHit(nominated, ballHit)
            };

            foreach (var ball in ballPotted ?? new List<Ball>())
            {
                _fouls.Add(new WrongBallPotted(nominated, ball));
            }
        }

        public bool Any()
        {
            return _fouls.Any(f => f.Commited());
        }

        public int PenaltyForCommited()
        {
            return _fouls.Where(f => f.Commited()).Max(f => f.Penalty());
        }
    }
}