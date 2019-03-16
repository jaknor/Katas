namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        private readonly Rover _rover;

        public TurnLeftCommand(Rover rover)
        {
            _rover = rover;
        }

        public Rover Move()
        {
            return new Rover(_rover.X, _rover.Y, _rover.Direction.Left());
        }
    }
}