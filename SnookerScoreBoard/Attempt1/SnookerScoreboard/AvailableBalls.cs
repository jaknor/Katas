namespace SnookerScoreboard
{
    using System.Collections.Generic;
    using System.Linq;

    internal class AvailableBalls
    {
        private const int PointsForBlackBall = 7;
        private const int PointsForRedBall = 1;

        private readonly List<Ball> _balls;
        private bool _hasChanceToPotBlackAfterRed;

        public AvailableBalls()
        {
            _balls = new List<Ball>
            {
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Red,
                Ball.Yellow,
                Ball.Green,
                Ball.Brown,
                Ball.Blue,
                Ball.Pink,
                Ball.Black
            };
        }

        public void AddShot(Shot shot)
        {
            _hasChanceToPotBlackAfterRed = CorrectlyPottedRed(shot);

            foreach (var ball in shot.PottedBalls())
            {
                if (BallShouldBeRemoved(ball))
                {
                    _balls.Remove(ball);
                }
            }
        }

        public int RemainingPoints()
        {
            return PossibleScoreFromRedBalls() + PossibleScoreFromColoredBalls();
        }

        private int PossibleScoreFromColoredBalls()
        {
            return _balls.Where(b => b != Ball.Red).Sum(b => (int)b);
        }

        private int PossibleScoreFromRedBalls()
        {
            var pointsRemainingFromReds = _balls.Count(b => b == Ball.Red) * (PointsForRedBall + PointsForBlackBall);

            if (_hasChanceToPotBlackAfterRed)
            {
                pointsRemainingFromReds += PointsForBlackBall;
            }

            return pointsRemainingFromReds;
        }

        private bool BallShouldBeRemoved(Ball ball)
        {
            return _balls.FirstOrDefault() == ball;
        }

        private bool CorrectlyPottedRed(Shot shot)
        {
            return !shot.Foul() && shot.PottedBalls().Any(b => b == Ball.Red);
        }
    }
}