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

        public bool FacingNorth => _direction == "N";

        public bool FacingSouth => _direction == "S";

        public bool FacingEast => _direction == "E";

        public bool FacingWest => _direction == "W";

        public Direction Left()
        {
            if (FacingNorth)
            {
                return West;
            }
            else if (FacingWest)
            {
                return South;
            }
            else if (FacingSouth)
            {
                return East;
            }
            else if (FacingEast)
            {
                return North;
            }

            return this;
        }

        public Direction Right()
        {
            if (FacingNorth)
            {
                return East;
            }
            else if (FacingWest)
            {
                return North;
            }
            else if (FacingSouth)
            {
                return West;
            }
            else if (FacingEast)
            {
                return South;
            }

            return this;
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