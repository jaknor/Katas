namespace MarsRover
{
    public class NoMoveCommand : IRoverCommand
    {
        private readonly RoverState _state;

        public NoMoveCommand(RoverState state)
        {
            _state = state;
        }

        public RoverState Move()
        {
            return _state;
        }
    }
}