namespace MarsRover
{
    using System.Collections.Generic;

    public class RoverCommandCenter
    {
        public RoverCommandCenter(Rover rover)
        {
            Rover = rover;
        }

        public Rover Rover { get; private set; }

        public void Execute(List<string> commands)
        {
            var roverCommandFactory = new RoverCommandFactory();
            foreach (var commandString in commands)
            {
                Rover = roverCommandFactory.GetCommand(commandString, Rover).Move();
            }
        }
    }
}