namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        private readonly Rover _rover;

        public TurnRightCommand(Rover rover)
        {
            _rover = rover;
        }

        public Rover Move()
        {
            var newDirection = _rover.Direction;
            if (_rover.FacingNorth)
            {
                newDirection = "E";
            }
            else if (_rover.FacingEast)
            {
                newDirection = "S";
            }
            else if (_rover.FacingSouth)
            {
                newDirection = "W";
            }
            else if (_rover.FacingWest)
            {
                newDirection = "N";
            }

            return new Rover(_rover.X, _rover.Y, newDirection);
        }
    }
}