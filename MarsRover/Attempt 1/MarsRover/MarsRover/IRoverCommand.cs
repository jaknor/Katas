namespace MarsRover
{
    public interface IRoverCommand
    {
        Rover Move(Rover current, Planet planet);

        string CommandPattern { get; }
    }
}