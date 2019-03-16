namespace MarsRover
{
    public class ForwardCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public ForwardCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
        {
            if (_roverState.Direction == "N")
            {
                return new RoverState(_roverState.X, _roverState.Y + 1, _roverState.Direction);
            }
            else if (_roverState.Direction == "E")
            {
                return new RoverState(_roverState.X + 1, _roverState.Y, _roverState.Direction);
            }
            else if (_roverState.Direction == "S")
            {
                return new RoverState(_roverState.X, _roverState.Y - 1, _roverState.Direction);
            }
            else if (_roverState.Direction == "W")
            {
                return new RoverState(_roverState.X -1, _roverState.Y, _roverState.Direction);
            }

            return new RoverState(_roverState.X, _roverState.Y, _roverState.Direction);
        }
    }
}