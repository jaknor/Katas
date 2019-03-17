namespace MarsRover
{
    public class ForwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, Planet planet)
        {
            var nextPosition = rover.Position.Forwards(rover.Direction, planet);

            if (rover.Sensor.CanMoveToTile(planet, nextPosition))
            {
                return new Rover(nextPosition, rover.Direction);
            }

            return rover;
        }

        public string CommandPattern => "f";
    }
}