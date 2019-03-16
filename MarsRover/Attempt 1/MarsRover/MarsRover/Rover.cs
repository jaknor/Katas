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
            foreach (var command in commands)
            {
                RoverState = new RoverState(RoverState.X, RoverState.Y + 1, RoverState.Direction);
            }
        }
    }
}