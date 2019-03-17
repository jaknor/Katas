namespace MarsRover
{
    public interface IRoverCommand
    {
        Rover Move(Rover current, Limit limit, Planet planet);

        string CommandPattern { get; }
    }
}