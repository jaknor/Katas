namespace MarsRover
{
    public class Direction
    {
        private readonly string _direction;

        public static Direction North => new Direction("N");

        public static Direction South => new Direction("S");

        public static Direction East => new Direction("E");

        public static Direction West => new Direction("W");

        public Direction(string direction)
        {
            _direction = direction;
        }

        protected bool Equals(Direction other)
        {
            return string.Equals(_direction, other._direction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Direction) obj);
        }

        public override int GetHashCode()
        {
            return (_direction != null ? _direction.GetHashCode() : 0);
        }
    }
}