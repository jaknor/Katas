namespace SnookerScoreboard1
{
    using System.Collections.Generic;
    using System.Linq;

    public class Attempt
    {
        private readonly Color _nominated;
        private readonly Ball _hit;
        private readonly List<Ball> _potted;

        public Attempt(Color nominated, Ball hit, List<Ball> potted)
        {
            _nominated = nominated;
            _hit = hit;
            _potted = potted;
        }

        public bool Foul()
        {
            return Missed() || HitWrongBall() || _potted.Any(p => p.Color != _nominated);
        }

        private bool Missed()
        {
            return _hit == null;
        }

        private bool HitWrongBall()
        {
            return _hit?.Color != _nominated;
        }

        public int ScoreForCurrentPlayer()
        {
            return Foul() ? 0 : 1;
        }

        public int ScoreForOpposition()
        {
            return Foul() ? 1 : 0;
        }
    }

    public class Ball
    {
        public Ball(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
    }

    public enum Color
    {
        Red
    }
}