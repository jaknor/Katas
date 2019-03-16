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
            if (_rover.Direction == "N")
            {
                newDirection = "W";
            }
            else if (_rover.Direction == "W")
            {
                newDirection = "S";
            }
            else if (_rover.Direction == "S")
            {
                newDirection = "E";
            }
            else if (_rover.Direction == "E")
            {
                newDirection = "N";
            }

            return new Rover(_rover.X, _rover.Y, newDirection);
        }
    }
}