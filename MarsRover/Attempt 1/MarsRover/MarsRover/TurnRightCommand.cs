namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public TurnRightCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
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

            return new RoverState(_roverState.X, _roverState.Y, newDirection);
        }
    }
}