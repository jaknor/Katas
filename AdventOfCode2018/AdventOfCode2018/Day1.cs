namespace AdventOfCode2018
{
    using Shouldly;
    using TestStack.BDDfy;
    using Xunit;

    public class Day1
    {
        private int _frequency;
        private string _input;

        [Fact]
        public void OnePositiveNumber()
        {
            this
                .Given(_ => GivenInput("+1"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(1))
                .BDDfy();
        }

        [Fact]
        public void AnotherPositiveNumber()
        {
            this
                .Given(_ => GivenInput("+2"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(2))
                .BDDfy();
        }

        private void GivenInput(string input)
        {
            _input = input;
        }

        private void WhenWeCalculateFrequency()
        {
            _frequency = new FrequencyCalculator().Calculate(_input);
        }

        private void ThenTheCalculatedFrequencyIs(int expectedFrequency)
        {
            _frequency.ShouldBe(expectedFrequency);
        }
    }
}
