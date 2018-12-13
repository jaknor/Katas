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

        [Fact]
        public void OneLineWithTwoAndNoThree()
        {
            this
                .Given(_ => GivenInput("bb"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(0))
                .BDDfy();
        }

        [Fact]
        public void OneLineWithThreeAndNoTwo()
        {
            this
                .Given(_ => GivenInput("bbb"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(0))
                .BDDfy();
        }

        [Fact]
        public void OneLineWithTwoAndFour()
        {
            this
                .Given(_ => GivenInput("bbaaaa"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(0))
                .BDDfy();
        }

        [Fact]
        public void OneLineWithTwoTwoAndAThree()
        {
            this
                .Given(_ => GivenInput("aabbccc"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(1))
                .BDDfy();
        }

        [Fact]
        public void OneLineWithATwoAndTwoThree()
        {
            this
                .Given(_ => GivenInput("aabbbccc"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(1))
                .BDDfy();
        }

        [Fact]
        public void MultipleLinesFirstWithTwoAndThreeSecondWithTwo()
        {
            this
                .Given(_ => GivenInput("aabbb|cc"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(2))
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
