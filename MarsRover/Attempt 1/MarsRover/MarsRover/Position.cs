namespace MarsRover
{
    public class Position
    {
        private readonly int _x;

        private readonly int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Position Forwards(Direction direction, Limit limit)
        {
            if (direction.FacingNorth)
            {
                return MoveNorth(limit);
            }
            else if (direction.FacingEast)
            {
                return MoveEast(limit);
            }
            else if (direction.FacingSouth)
            {
                return MoveSouth(limit);
            }
            else if (direction.FacingWest)
            {
                return MoveWest(limit);
            }

            return this;
        }

        public Position Backwards(Direction direction, Limit limit)
        {
            if (direction.FacingNorth)
            {
                return MoveSouth(limit);
            }
            else if (direction.FacingEast)
            {
                return MoveWest(limit);
            }
            else if (direction.FacingSouth)
            {
                return MoveNorth(limit);
            }
            else if (direction.FacingWest)
            {
                return MoveEast(limit);
            }

            return this;
        }

        private Position MoveSouth(Limit limit)
        {
            var coordinateAdjustedForLimit = limit.AdjustForLimitReached(_y);

            return new Position(_x, coordinateAdjustedForLimit - 1);
        }

        private Position MoveWest(Limit limit)
        {
            var coordinateAdjustedForLimit = limit.AdjustForLimitReached(_x);
            
            return new Position(coordinateAdjustedForLimit - 1, _y);
        }

        private Position MoveNorth(Limit limit)
        {
            var coordinateAdjustedForLimit = limit.AdjustForLimitReached(_y);

            return new Position(_x, coordinateAdjustedForLimit + 1);
        }

        private Position MoveEast(Limit limit)
        {
            var coordinateAdjustedForLimit = limit.AdjustForLimitReached(_x);

            return new Position(coordinateAdjustedForLimit + 1, _y);
        }

        public override string ToString()
        {
            return $"({_x},{_y})";
        }

        protected bool Equals(Position other)
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x * 397) ^ _y;
            }
        }
    }
}