namespace MarsRover
{
    public class NoMoveCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Planet planet)
        {
            return rover;
        }

        public string CommandPattern => string.Empty;
    }
}