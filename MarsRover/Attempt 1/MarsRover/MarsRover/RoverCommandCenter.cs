namespace MarsRover
{
    using System.Collections.Generic;

    public class RoverCommandCenter
    {
        private readonly Planet _planet;
        private readonly Limit _limit;
        private readonly RoverCommandFactory _roverCommandFactory;

        public RoverCommandCenter(Rover rover) : this(rover, int.MaxValue) { }

        public RoverCommandCenter(Rover rover, int limit) : this(rover, limit, new Planet(new List<Position>())) { }

        public RoverCommandCenter(Rover rover, int limit, Planet planet)
        {
            _planet = planet;
            Rover = rover;
            _limit = new Limit(limit);
            _roverCommandFactory = new RoverCommandFactory();
        }

        public Rover Rover { get; private set; }

        public void Execute(List<string> commands)
        {
            foreach (var commandString in commands)
            {
                var movedRover = _roverCommandFactory.GetCommand(commandString).Move(Rover, _limit, _planet);
                movedRover.Report();
                if (movedRover.Sensor.IsStuck())
                {
                    break;
                }
                Rover = movedRover;
            }
        }
    }
}