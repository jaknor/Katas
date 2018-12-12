namespace AdventOfCode2018
{
    internal class FrequencyCalculator
    {
        public int Calculate(string input)
        {
            var sign = input.Substring(0, 1);

            if (sign == "+")
            {
                return int.Parse(input.Substring(1));
            }

            return -int.Parse(input.Substring(1));
        }
    }
}