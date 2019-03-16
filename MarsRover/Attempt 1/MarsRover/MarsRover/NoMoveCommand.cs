namespace MarsRover
{
    public class NoMoveCommand : IRoverCommand
    {
        private readonly Rover _state;

        public NoMoveCommand(Rover state)
        {
            _state = state;
        }

        public Rover Move()
        {
            return _state;
        }
    }
}