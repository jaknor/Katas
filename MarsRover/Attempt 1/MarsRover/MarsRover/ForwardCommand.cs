namespace MarsRover
{
    public class ForwardCommand : MoveCommand, IRoverCommand
    {
        private readonly Rover _roverState;
        private readonly int _limit;

        public ForwardCommand(Rover roverState, int limit)
        {
            _roverState = roverState;
            _limit = limit;
        }

        public Rover Move()
        {
            if (_roverState.Direction == "N")
            {
                return new Rover(_roverState.X, MoveNorth(_roverState, _limit), _roverState.Direction);
            }
            else if (_roverState.Direction == "E")
            {
                return new Rover(MoveEast(_roverState, _limit), _roverState.Y, _roverState.Direction);
            }
            else if (_roverState.Direction == "S")
            {
                return new Rover(_roverState.X, MoveSouth(_roverState, _limit), _roverState.Direction);
            }
            else if (_roverState.Direction == "W")
            {
                return new Rover(MoveWest(_roverState, _limit), _roverState.Y, _roverState.Direction);
            }

            return new Rover(_roverState.X, _roverState.Y, _roverState.Direction);
        }
    }
}