namespace MarsRover
{
    public class BackwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Limit limit, Planet planet)
        {
            var nextPosition = rover.Position.Backwards(rover.Direction, limit);

            if (rover.Sensor.CanMoveToTile(planet, nextPosition))
            {
                return new Rover(nextPosition, rover.Direction);
            }

            return rover;
        }

        public string CommandPattern => "b";
    }
}