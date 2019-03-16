namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand GetCommand(string commandString, Rover roverState, int limit)
        {
            if (commandString == "f")
            {
                return new ForwardCommand(roverState, limit);
            }

            if (commandString == "b")
            {
                return new BackwardCommand(roverState, limit);
            }

            if (commandString == "r")
            {
                return new TurnRightCommand(roverState);
            }

            if (commandString == "l")
            {
                return new TurnLeftCommand(roverState);
            }

            return new NoMoveCommand(roverState);
        }
    }
}