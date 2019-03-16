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
            if (_rover.Direction == "N")
            {
                newDirection = "E";
            }
            else if (_rover.Direction == "E")
            {
                newDirection = "S";
            }
            else if (_rover.Direction == "S")
            {
                newDirection = "W";
            }
            else if (_rover.Direction == "W")
            {
                newDirection = "N";
            }

            return new Rover(_rover.X, _rover.Y, newDirection);
        }
    }
}