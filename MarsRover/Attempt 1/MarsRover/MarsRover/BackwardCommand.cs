namespace MarsRover
{
    public class BackwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.Position.Backwards(rover.Direction, limit), rover.Direction);
        }

        public string CommandPattern => "b";
    }
}