namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.X, rover.Y, rover.Direction.Right());
        }

        public string CommandPattern => "r";
    }
}