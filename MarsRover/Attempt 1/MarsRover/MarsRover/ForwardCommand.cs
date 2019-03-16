namespace MarsRover
{
    public class ForwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            if (rover.Direction.FacingNorth)
            {
                return rover.MoveNorth(limit);
            }
            else if (rover.Direction.FacingEast)
            {
                return rover.MoveEast(limit);
            }
            else if (rover.Direction.FacingSouth)
            {
                return rover.MoveSouth(limit);
            }
            else if (rover.Direction.FacingWest)
            {
                return rover.MoveWest(limit);
            }

            return rover;
        }

        public string CommandPattern => "f";
    }
}