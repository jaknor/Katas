namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        private readonly Rover _roverState;

        public TurnRightCommand(Rover roverState)
        {
            _roverState = roverState;
        }

        public Rover Move()
        {
            var newDirection = _roverState.Direction;
            if (_roverState.Direction == "N")
            {
                newDirection = "E";
            }
            else if (_roverState.Direction == "E")
            {
                newDirection = "S";
            }
            else if (_roverState.Direction == "S")
            {
                newDirection = "W";
            }
            else if (_roverState.Direction == "W")
            {
                newDirection = "N";
            }

            return new Rover(_roverState.X, _roverState.Y, newDirection);
        }
    }
}