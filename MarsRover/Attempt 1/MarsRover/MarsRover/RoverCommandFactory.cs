namespace MarsRover
{
    using System.Collections.Generic;
    using System.Linq;

    public class RoverCommandFactory
    {
        private readonly List<IRoverCommand> _availableCommands = new List<IRoverCommand>
        {
            new ForwardCommand(),
            new BackwardCommand(),
            new TurnLeftCommand(),
            new TurnRightCommand(),
            new NoMoveCommand()
        };

        public IRoverCommand GetCommand(string commandString)
        {
            return _availableCommands.First(x =>
                x.CommandPattern == commandString || string.IsNullOrEmpty(x.CommandPattern));
        }
    }
}