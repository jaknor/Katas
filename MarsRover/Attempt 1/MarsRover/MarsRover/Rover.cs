namespace MarsRover
{
    using System.Collections.Generic;

    public class Rover
    {
        public Rover(RoverState roverState)
        {
            RoverState = roverState;
        }

        public RoverState RoverState { get; private set; }

        public void Execute(List<string> commands)
        {
            var roverCommandFactory = new RoverCommandFactory();
            foreach (var commandString in commands)
            {
                RoverState = roverCommandFactory.GetCommand(commandString, RoverState).Move();
            }
        }
    }
}