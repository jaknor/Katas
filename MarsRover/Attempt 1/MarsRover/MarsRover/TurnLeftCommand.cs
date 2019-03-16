namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        private readonly Rover _roverState;

        public TurnLeftCommand(Rover roverState)
        {
            _roverState = roverState;
        }

        public Rover Move()
        {
            var newDirection = _roverState.Direction;
            if (_roverState.Direction == "N")
            {
                newDirection = "W";
            }
            else if (_roverState.Direction == "W")
            {
                newDirection = "S";
            }
            else if (_roverState.Direction == "S")
            {
                newDirection = "E";
            }
            else if (_roverState.Direction == "E")
            {
                newDirection = "N";
            }

            return new Rover(_roverState.X, _roverState.Y, newDirection);
        }
    }
}