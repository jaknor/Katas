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

        public Position Forwards(Direction direction, Planet planet)
        {
            if (direction.FacingNorth)
            {
                return MoveNorth(planet);
            }
            else if (direction.FacingEast)
            {
                return MoveEast(planet);
            }
            else if (direction.FacingSouth)
            {
                return MoveSouth(planet);
            }
            else if (direction.FacingWest)
            {
                return MoveWest(planet);
            }

            return this;
        }

        public Position Backwards(Direction direction, Planet planet)
        {
            if (direction.FacingNorth)
            {
                return MoveSouth(planet);
            }
            else if (direction.FacingEast)
            {
                return MoveWest(planet);
            }
            else if (direction.FacingSouth)
            {
                return MoveNorth(planet);
            }
            else if (direction.FacingWest)
            {
                return MoveEast(planet);
            }

            return this;
        }

        private Position MoveSouth(Planet planet)
        {
            var coordinateAdjustedForLimit = planet.AdjustForLimitReached(_y);

            return new Position(_x, coordinateAdjustedForLimit - 1);
        }

        private Position MoveWest(Planet planet)
        {
            var coordinateAdjustedForLimit = planet.AdjustForLimitReached(_x);
            
            return new Position(coordinateAdjustedForLimit - 1, _y);
        }

        private Position MoveNorth(Planet planet)
        {
            var coordinateAdjustedForLimit = planet.AdjustForLimitReached(_y);

            return new Position(_x, coordinateAdjustedForLimit + 1);
        }

        private Position MoveEast(Planet planet)
        {
            var coordinateAdjustedForLimit = planet.AdjustForLimitReached(_x);

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