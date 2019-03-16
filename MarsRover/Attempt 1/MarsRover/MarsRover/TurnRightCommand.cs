namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.Position, rover.Direction.Right());
        }

        public string CommandPattern => "r";
    }
}