namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand GetCommand(string commandString, Rover rover, int limit)
        {
            if (commandString == "f")
            {
                return new ForwardCommand(rover, limit);
            }

            if (commandString == "b")
            {
                return new BackwardCommand(rover, limit);
            }

            if (commandString == "r")
            {
                return new TurnRightCommand(rover);
            }

            if (commandString == "l")
            {
                return new TurnLeftCommand(rover);
            }

            return new NoMoveCommand(rover);
        }
    }
}