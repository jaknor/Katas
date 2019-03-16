namespace MarsRover
{
    public class NoMoveCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return rover;
        }

        public string CommandPattern => string.Empty;
    }
}