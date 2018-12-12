namespace AdventOfCode2018.Day1
{
    using System.Collections.Generic;

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

        public int FindFirstFrequencyToBeRepeated(string input)
        {
            var frequencies = new HashSet<int>() {0};
            var frequency = 0;
            var values = input.Split("|");

            while (true)
            {
                foreach (var value in values)
                {
                    var sign = value.Substring(0, 1);
                    var frequencyChange = int.Parse(value.Substring(1));

                    if (sign == "-")
                    {
                        frequencyChange = -frequencyChange;
                    }

                    frequency += frequencyChange;
                    if (frequencies.Contains(frequency))
                    {
                        return frequency;
                    }
                    frequencies.Add(frequency);
                }
            }
        }
    }
}