namespace AdventOfCode2018.Day2
{
    internal class ChecksumCalculator
    {
        public int Calculate(string input)
        {
            if (input.Length > 1)
            {
                return 1;
            }

            return 0;
        }
    }
}