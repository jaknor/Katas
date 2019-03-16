namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.X, rover.Y, rover.Direction.Left());
        }

        public string CommandPattern => "l";
    }
}