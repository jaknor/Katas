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
            foreach (var commandString in commands)
            {
                var command = new RoverCommandFactory().Build(commandString, RoverState);
                RoverState = command.Move();
            }
        }
    }
}