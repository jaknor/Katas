namespace MarsRover
{
    using System.Collections.Generic;

    public class RoverCommandCenter
    {
        private int _limit;

        public RoverCommandCenter(Rover rover) : this(rover, int.MaxValue) { }

        public RoverCommandCenter(Rover rover, int limit)
        {
            Rover = rover;
            _limit = limit;
        }

        public Rover Rover { get; private set; }

        public void Execute(List<string> commands)
        {
            var roverCommandFactory = new RoverCommandFactory();
            foreach (var commandString in commands)
            {
                Rover = roverCommandFactory.GetCommand(commandString, Rover, _limit).Move();
            }
        }
    }
}