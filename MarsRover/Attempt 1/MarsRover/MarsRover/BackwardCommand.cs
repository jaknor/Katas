namespace MarsRover
{
    public class BackwardCommand : MoveCommand, IRoverCommand
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
            if (_rover.Direction == "N")
            {
                return new Rover(_rover.X, MoveSouth(_rover, _limit), _rover.Direction);
            }
            else if (_rover.Direction == "E")
            {
                return new Rover(MoveWest(_rover, _limit), _rover.Y, _rover.Direction);
            }
            else if (_rover.Direction == "S")
            {
                return new Rover(_rover.X, MoveNorth(_rover, _limit), _rover.Direction);
            }
            else if (_rover.Direction == "W")
            {
                return new Rover(MoveEast(_rover, _limit), _rover.Y, _rover.Direction);
            }

            return new Rover(_rover.X, _rover.Y, _rover.Direction);
        }
    }
}