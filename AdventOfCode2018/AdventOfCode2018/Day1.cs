namespace AdventOfCode2018
{
    using Shouldly;
    using TestStack.BDDfy;
    using Xunit;

    public class Day1
    {
        private int _frequency;
        private string _input;

        [Theory]
        [InlineData("+1", 1)]
        [InlineData("+2", 2)]
        [InlineData("+24", 24)]
        [InlineData("+561", 561)]
        public void SinglePositiveNumbers(string input, int expectedFrequency)
        {
            this
                .Given(_ => GivenInput(input))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(expectedFrequency))
                .BDDfy();
        }

        [Theory]
        [InlineData("-1", -1)]
        [InlineData("-2", -2)]
        [InlineData("-24", -24)]
        [InlineData("-561", -561)]
        public void SingleNegativeNumbers(string input, int expectedFrequency)
        {
            this
                .Given(_ => GivenInput(input))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(expectedFrequency))
                .BDDfy();
        }

        [Fact]
        public void MultiplePositiveNumbers()
        {
            this
                .Given(_ => GivenInput("+1|+3|+4"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(8))
                .BDDfy();
        }

        [Fact]
        public void MultipleNegativeNumbers()
        {
            this
                .Given(_ => GivenInput("-1|-3|-4"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(-8))
                .BDDfy();
        }

        [Fact]
        public void MultipleMixedValuesWithPositiveResult()
        {
            this
                .Given(_ => GivenInput("+1|-3|-4|+10"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(4))
                .BDDfy();
        }

        [Fact]
        public void MultipleMixedValuesWithNegativeResult()
        {
            this
                .Given(_ => GivenInput("-1|+3|+4|-10"))
                .When(_ => WhenWeCalculateFrequency())
                .Then(_ => ThenTheCalculatedFrequencyIs(-4))
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
