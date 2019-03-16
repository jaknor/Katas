namespace MarsRover
{
    public class BackwardCommand : IRoverCommand
    {
        public Rover Move(Rover rover, int limit)
        {
            if (rover.Direction.FacingNorth)
            {
                return rover.MoveSouth(limit);
            }
            else if (rover.Direction.FacingEast)
            {
                return rover.MoveWest(limit);
            }
            else if (rover.Direction.FacingSouth)
            {
                return rover.MoveNorth(limit);
            }
            else if (rover.Direction.FacingWest)
            {
                return rover.MoveEast(limit);
            }

            return rover;
        }

        public string CommandPattern => "b";
    }
}