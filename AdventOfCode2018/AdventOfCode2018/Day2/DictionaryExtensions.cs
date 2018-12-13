namespace AdventOfCode2018.Day2
{
    using System.Collections.Generic;

    internal static class DictionaryExtensions
    {
        public static void Increase(this Dictionary<char, int> dictionary, char key, int increase)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
                return;
            }

            dictionary[key] = 1;
        }
    }
}