namespace AdventOfCode2018.Day2
{
    internal class ChecksumCalculator
    {
        public int Calculate(string input)
        {
            var lines = input.Split("|");

            int twos = 0, threes = 0;
            foreach (var line in lines)
            {
                var counts = new CharacterCounter().CountCharacters(line);
                twos += counts.twoCount;
                threes += counts.threeCount;
            }

            return twos * threes;
        }
    }
}