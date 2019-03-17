namespace MarsRover
{
    public class ForwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit, Planet planet)
        {
            var nextPosition = rover.Position.Forwards(rover.Direction, limit);

            if (rover.Sensor.CanMoveToTile(planet, nextPosition))
            {
                return new Rover(nextPosition, rover.Direction);
            }

            return rover;
        }

        public string CommandPattern => "f";
    }
}