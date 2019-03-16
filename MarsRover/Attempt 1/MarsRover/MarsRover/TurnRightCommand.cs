namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        private readonly Rover _rover;

        public TurnRightCommand(Rover rover)
        {
            _rover = rover;
        }

        public Rover Move()
        {
            return new Rover(_rover.X, _rover.Y, _rover.Direction.Right());
        }
    }
}