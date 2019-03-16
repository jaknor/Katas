namespace MarsRover
{
    public interface IRoverCommand
    {
        Rover Move(Rover current, int limit);

        string CommandPattern { get; }
    }
}