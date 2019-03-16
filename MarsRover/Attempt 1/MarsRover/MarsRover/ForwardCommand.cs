namespace MarsRover
{
    public class ForwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            return new Rover(rover.Position.Forwards(rover.Direction, limit), rover.Direction);
        }

        public string CommandPattern => "f";
    }
}