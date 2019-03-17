namespace MarsRover
{
    public interface IRoverCommand
    {
        Rover Move(Rover current, Limit limit);

        string CommandPattern { get; }
    }
}