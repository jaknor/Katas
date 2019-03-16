namespace MarsRover
{
    public class ForwardSouthCommand : IRoverCommand
    {
        private readonly RoverState _roverState;

        public ForwardSouthCommand(RoverState roverState)
        {
            _roverState = roverState;
        }

        public RoverState Move()
        {
            return new RoverState(_roverState.X, _roverState.Y - 1, _roverState.Direction);
        }
    }
}