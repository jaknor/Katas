namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        private readonly Rover _rover;

        public TurnLeftCommand(Rover rover)
        {
            _rover = rover;
        }

        public Rover Move()
        {
            var newDirection = _rover.Direction;
            if (_rover.FacingNorth)
            {
                newDirection = Direction.West;
            }
            else if (_rover.FacingWest)
            {
                newDirection = Direction.South;
            }
            else if (_rover.FacingSouth)
            {
                newDirection = Direction.East;
            }
            else if (_rover.FacingEast)
            {
                newDirection = Direction.North;
            }

            return new Rover(_rover.X, _rover.Y, newDirection);
        }
    }
}