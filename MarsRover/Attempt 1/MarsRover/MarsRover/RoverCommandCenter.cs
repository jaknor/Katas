namespace MarsRover
{
    using System;
    using System.Collections.Generic;

    public class RoverCommandCenter
    {
        private readonly Planet _planet;
        private readonly RoverCommandFactory _roverCommandFactory;

        public RoverCommandCenter(Rover rover) : this(rover, Int32.MaxValue) { }

        public RoverCommandCenter(Rover rover, int limit) : this(rover, new Planet(new Limit(limit), new List<Position>())) { }

        public RoverCommandCenter(Rover rover, Planet planet)
        {
            _planet = planet;
            _roverCommandFactory = new RoverCommandFactory();
            Rover = rover;
        }

        public Rover Rover { get; private set; }

        public void Execute(List<string> commands)
        {
            foreach (var commandString in commands)
            {
                var movedRover = _roverCommandFactory.GetCommand(commandString).Move(Rover, _planet);
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