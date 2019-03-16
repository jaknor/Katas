namespace MarsRover
{
    public class RoverCommandFactory
    {
        public IRoverCommand Build(string commandString, RoverState roverState)
        {
            if (roverState.Direction == "N" && commandString == "f")
            {
                return new ForwardNorthCommand(roverState);
            }
            if (roverState.Direction == "E" && commandString == "f")
            {
                return new ForwardEastCommand(roverState);
            }
            if (roverState.Direction == "S" && commandString == "f")
            {
                return new ForwardSouthCommand(roverState);
            }

            return new NoMoveCommand(roverState);
        }
    }
}