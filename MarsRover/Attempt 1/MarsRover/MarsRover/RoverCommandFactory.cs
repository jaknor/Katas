namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand Build(string commandString, RoverState roverState)
        {
            if (commandString == "f")
            {
                return new ForwardCommand(roverState);
            }

            if (commandString == "r")
            {
                return new TurnRightCommand(roverState);
            }

            if (commandString == "l")
            {
                return new TurnLeftCommand(roverState);
            }

            return new NoMoveCommand(roverState);
        }
    }

    public class TurnLeftCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public TurnLeftCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
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

            return new RoverState(_roverState.X, _roverState.Y, newDirection);
        }
    }
}