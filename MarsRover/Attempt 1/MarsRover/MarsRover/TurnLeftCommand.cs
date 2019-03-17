namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit)
        {
            return new Rover(rover.Position, rover.Direction.Left());
        }

        public string CommandPattern => "l";
    }
}