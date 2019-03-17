namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit, Planet planet)
        {
            return new Rover(rover.Position, rover.Direction.Right());
        }

        public string CommandPattern => "r";
    }
}