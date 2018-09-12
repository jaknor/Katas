namespace FizzBuzz
{
    internal class BuzzRule : IRule
    {
        public string Value(int value)
        {
            var output = string.Empty;

            if (value % 5 == 0)
            {
                output = "Buzz";
            }

            return output;
        }
    }
}