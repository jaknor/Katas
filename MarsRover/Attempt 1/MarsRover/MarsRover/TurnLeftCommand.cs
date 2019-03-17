namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit, Planet planet)
        {
            return new Rover(rover.Position, rover.Direction.Left());
        }

        public string CommandPattern => "l";
    }
}