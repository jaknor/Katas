namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand Build(string commandString, RoverState roverState)
        {
            if (commandString == "f")
            {
                return new ForwardCommand(roverState);
            }

            if (commandString == "r")
            {
                return new TurnRightCommand(roverState);
            }

            return new NoMoveCommand(roverState);
        }
    }
}