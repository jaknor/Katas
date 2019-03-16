namespace MarsRover
{
    public class Rover
    {
        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public Position Position { get; }

        public Direction Direction { get; }

        public override string ToString()
        {
            return $"Position: {Position}, Direction: {Direction}";
        }

        protected bool Equals(Rover other)
        {
            return Equals(Position, other.Position) && Equals(Direction, other.Direction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Position != null ? Position.GetHashCode() : 0) * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
            }
        }
    }
}