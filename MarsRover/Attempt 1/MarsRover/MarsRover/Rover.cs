namespace MarsRover
{
    public class Rover
    {
        public Rover(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public string Direction { get; private set; }

        public void Execute(string command)
        {
            Y++;
        }
    }
}