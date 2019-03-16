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
                newDirection = "W";
            }
            else if (_rover.FacingWest)
            {
                newDirection = "S";
            }
            else if (_rover.FacingSouth)
            {
                newDirection = "E";
            }
            else if (_rover.FacingEast)
            {
                newDirection = "N";
            }

            return new Rover(_rover.X, _rover.Y, newDirection);
        }
    }
}