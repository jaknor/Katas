namespace FizzBuzz
{
    internal class FizzRule : IRule
    {
        public string Value(int value)
        {
            var output = string.Empty;

            if (value % 3 == 0)
            {
                output = "Fizz";
            }

            return output;
        }
    }
}