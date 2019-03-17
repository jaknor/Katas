namespace MarsRover
{
    using System.Collections.Generic;

    public class RoverCommandCenter
    {
        private readonly Limit _limit;
        private readonly RoverCommandFactory _roverCommandFactory;

        public RoverCommandCenter(Rover rover) : this(rover, int.MaxValue) { }

        public RoverCommandCenter(Rover rover, int limit)
        {
            Rover = rover;
            _limit = new Limit(limit);
            _roverCommandFactory = new RoverCommandFactory();
        }

        public Rover Rover { get; private set; }

        public void Execute(List<string> commands)
        {
            foreach (var commandString in commands)
            {
                Rover = _roverCommandFactory.GetCommand(commandString).Move(Rover, _limit);
            }
        }
    }
}