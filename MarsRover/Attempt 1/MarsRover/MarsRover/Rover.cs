namespace MarsRover
{
    public class Rover
    {
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Direction: {Direction}";
        }

        protected bool Equals(Rover other)
        {
            return X == other.X && Y == other.Y && string.Equals(Direction, other.Direction);
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
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
                return hashCode;
            }
        }

        public Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; }

        public int Y { get; }

        public Direction Direction { get; }


        public bool FacingNorth => Equals(Direction, Direction.North);

        public bool FacingSouth => Equals(Direction, Direction.South);

        public bool FacingEast => Equals(Direction, Direction.East);

        public bool FacingWest => Equals(Direction, Direction.West);


        public Rover MoveSouth(int limit)
        {
            var currentY = Y;
            if (currentY == -limit)
            {
                currentY = limit + 1;
            };

            return new Rover(X, currentY - 1, Direction);
        }

        public Rover MoveWest(int limit)
        {
            var currentX = X;
            if (currentX == -limit)
            {
                currentX = (limit + 1);
            }

            return new Rover(currentX - 1, Y, Direction);
        }

        public Rover MoveNorth(int limit)
        {
            var currentY = Y;
            if (currentY == limit)
            {
                currentY = -(limit + 1);
            }

            return new Rover(X, currentY + 1, Direction);
        }

        public Rover MoveEast(int limit)
        {
            var currentX = X;
            if (currentX == limit)
            {
                currentX = -(limit + 1);
            }

            return new Rover(currentX + 1, Y, Direction);
        }
    }
}