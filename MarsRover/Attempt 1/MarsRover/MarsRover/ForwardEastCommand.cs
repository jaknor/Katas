namespace MarsRover
{
    public class ForwardEastCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public ForwardEastCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
        {
            return new RoverState(_roverState.X + 1, _roverState.Y, _roverState.Direction);
        }
    }
}