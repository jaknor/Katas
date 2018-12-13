namespace AdventOfCode2018.Day2
{
    using System.Collections.Generic;
    using System.Linq;

    internal class CharacterCounter
    {
        public (int twoCount, int threeCount) CountCharacters(string input)
        {
            var counts = new Dictionary<char, int>();

            foreach (var character in input)
            {
                counts.Increase(character, 1);
            }

            var twos = counts.Any(c => c.Value == 2) ? 1 : 0;
            var threes = counts.Any(c => c.Value == 3) ? 1 : 0;

            return (twos, threes);
        }
    }
}