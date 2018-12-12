namespace AdventOfCode2018.Day1
{
    using Shouldly;
    using TestStack.BDDfy;
    using Xunit;

    public class Part2
    {
        private int _firstFrequencyToBeRepeated;
        private string _input;

        [Fact]
        public void SimpleLoop()
        {
            this
                .Given(_ => GivenInput("+1|-1"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheFirstFrequencyToBeRepeatedIs(0))
                .BDDfy();
        }

        private void GivenInput(string input)
        {
            _input = input;
        }

        private void WhenWeCalculateFrequency()
        {
            _firstFrequencyToBeRepeated = new FrequencyCalculator().FindFirstFrequencyToBeRepeated(_input);
        }

        private void ThenTheFirstFrequencyToBeRepeatedIs(int expectedFrequency)
        {
            _firstFrequencyToBeRepeated.ShouldBe(expectedFrequency);
        }
    }
}
