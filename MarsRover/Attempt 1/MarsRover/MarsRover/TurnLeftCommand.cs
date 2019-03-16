namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.Position, rover.Direction.Left());
        }

        public string CommandPattern => "l";
    }
}