namespace AdventOfCode2018
{
    internal class FrequencyCalculator
    {
        public int Calculate(string input)
        {
            var frequency = 0;
            var values = input.Split("|");

            foreach (var value in values)
            {
                var sign = value.Substring(0, 1);
                var frequencyChange = int.Parse(value.Substring(1));

                if (sign == "-")
                {
                    frequencyChange = -frequencyChange;
                }

                frequency += frequencyChange;
            }

            return frequency;
        }
    }
}