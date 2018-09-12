namespace LeapYear
{
    internal static class YearExtensions
    {
        public static bool IsDividableBy(this int year, int divisor)
        {
            return year % divisor == 0;
        }
    }
}