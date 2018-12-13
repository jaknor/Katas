namespace AdventOfCode2018.Day2
{
    internal class ChecksumCalculator
    {
        public int Calculate(string input)
        {
            var counts = new CharacterCounter().CountCharacters(input);

            return counts.twoCount * counts.threeCount;
        }
    }
}