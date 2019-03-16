namespace MarsRover
{
    public class ForwardWestCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public ForwardWestCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
        {
            return new RoverState(_roverState.X - 1, _roverState.Y, _roverState.Direction);
        }
    }
}