namespace SnookerScoreboard
{
    using System.Collections.Generic;
    using System.Linq;

    public class Shot
    {
        private readonly Ball _nominated;
        private readonly List<Ball> _ballsPotted;
        private readonly PossibleFouls _possibleFouls;

        public Shot(Ball? ballHit, List<Ball> ballPotted, Ball nominated = Ball.Red)
        {
            _nominated = nominated;
            _ballsPotted = ballPotted ?? new List<Ball>();
            _possibleFouls = new PossibleFouls(nominated, ballHit, ballPotted);
        }

        public bool Foul()
        {
            return _possibleFouls.Any();
        }

        public int Score()
        {
            return _ballsPotted.Sum(b => (int)b);
        }

        public int Penalty()
        {
            return _possibleFouls.PenaltyForCommited();
        }

        public bool OtherPlayersTurn()
        {
            return !(PottedOnlyTheCorrectBall());
        }

        public List<Ball> PottedBalls()
        {
            return _ballsPotted;
        }

        private bool PottedOnlyTheCorrectBall()
        {
            return PottedAtleastOneBall() && ThePottedBallsAllMatchTheCorrectColor();
        }

        private bool ThePottedBallsAllMatchTheCorrectColor()
        {
            return _ballsPotted.All(b => b == _nominated);
        }

        private bool PottedAtleastOneBall()
        {
            return _ballsPotted.Count >= 1;
        }
    }
}

