namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand GetCommand(string commandString, Rover roverState)
        {
            if (commandString == "f")
            {
                return new ForwardCommand(roverState);
            }

            if (commandString == "b")
            {
                return new BackwardCommand(roverState);
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