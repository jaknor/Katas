namespace MarsRover
{
    public class BackwardCommand : IRoverCommand
    {
        private readonly Rover _roverState;

        public BackwardCommand(Rover roverState)
        {
            _roverState = roverState;
        }

        public Rover Move()
        {
            if (_roverState.Direction == "N")
            {
                return new Rover(_roverState.X, _roverState.Y - 1, _roverState.Direction);
            }
            else if (_roverState.Direction == "E")
            {
                return new Rover(_roverState.X - 1, _roverState.Y, _roverState.Direction);
            }
            else if (_roverState.Direction == "S")
            {
                return new Rover(_roverState.X, _roverState.Y + 1, _roverState.Direction);
            }
            else if (_roverState.Direction == "W")
            {
                return new Rover(_roverState.X + 1, _roverState.Y, _roverState.Direction);
            }

            return new Rover(_roverState.X, _roverState.Y, _roverState.Direction);
        }
    }
}