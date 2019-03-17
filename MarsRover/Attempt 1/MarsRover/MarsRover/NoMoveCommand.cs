namespace MarsRover
{
    public class NoMoveCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit, Planet planet)
        {
            return rover;
        }

        public string CommandPattern => string.Empty;
    }
}