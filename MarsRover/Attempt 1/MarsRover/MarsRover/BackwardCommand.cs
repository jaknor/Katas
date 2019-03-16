namespace MarsRover
{
    public class BackwardCommand : IRoverCommand
    {
        private readonly Rover _rover;
        private readonly int _limit;

        public BackwardCommand(Rover rover, int limit)
        {
            _rover = rover;
            _limit = limit;
        }

        public Rover Move()
        {
            if (_rover.Direction.FacingNorth)
            {
                return _rover.MoveSouth(_limit);
            }
            else if (_rover.Direction.FacingEast)
            {
                return _rover.MoveWest(_limit);
            }
            else if (_rover.Direction.FacingSouth)
            {
                return _rover.MoveNorth(_limit);
            }
            else if (_rover.Direction.FacingWest)
            {
                return _rover.MoveEast(_limit);
            }

            return _rover;
        }
    }
}