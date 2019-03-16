namespace MarsRover
{
    public class RoverState
    {
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Direction: {Direction}";
        }

        protected bool Equals(RoverState other)
        {
            return X == other.X && Y == other.Y && string.Equals(Direction, other.Direction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RoverState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
                return hashCode;
            }
        }

        public RoverState(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; }

        public int Y { get; }

        public string Direction { get; }
    }
}