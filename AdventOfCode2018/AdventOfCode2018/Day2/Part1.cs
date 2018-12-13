namespace AdventOfCode2018.Day2
{
    using Shouldly;
    using TestStack.BDDfy;
    using Xunit;

    public class Part1
    {
        private string _input;
        private int _result;

        [Fact]
        public void EmptyInput()
        {
            this
                .Given(_ => GivenInput(""))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(0))
                .BDDfy();
        }

        [Fact]
        public void OneLineWithTwoAndThree()
        {
            this
                .Given(_ => GivenInput("aaabb"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(1))
                .BDDfy();
        }

        private void GivenInput(string input)
        {
            _input = input;
        }

        private void WhenWeCalculateChecksum()
        {
            _result = new ChecksumCalculator().Calculate(_input);
        }

        private void ThenTheChecksumIs(int expectedChecksum)
        {
            _result.ShouldBe(expectedChecksum);
        }
    }
}
