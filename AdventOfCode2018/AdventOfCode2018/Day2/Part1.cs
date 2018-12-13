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

        [Fact]
        public void Part1Input()
        {
            this
                .Given(_ => GivenInput("kbqwtcvzgumhpwelrnaxydpfuj|kbqwtcvzgsmhpoelryaxydiqij|kbqwpcvzssmhpoelgnaxydifuj|kbqgtcvxgsmhpoalrnaxydifuj|kbqwtcvygsmhpoelrnaxydiaut|kbqwtcvjgsmhpoelrnawydzfuj|kbqftcvzgsmhpoeprnaxydifus|rbqwtcgzgsxhpoelrnaxydifuj|kbqwtlvzgvmhpoelrnaxkdifuj|kbqwtcvzgsmhpolqrnaxydifub|kbqbtcqzgsmhposlrnaxydifuj|kbqwmcvzgswhpoelxnaxydifuj|kbqwtyvzgsmhkoelrnsxydifuj|khqwtcvzgsmhqoelinaxydifuj|koqwtcvzcsmhpoelrnaxydizuj|kbqwtcvzlsmhpoezrnaxydmfuj|kbqwtcvzdsmhpoelrjaxydifij|kbqwtcvzgsmhpoelrncxyjifuk|kbtwtcvzgsmhpoelonaxydiwuj|kbqwfcrzgsmhpoelrnaeydifuj|kbqutcvkgsmhpoelrnfxydifuj|kbqwtcvzgsmvvoelrnaxydihuj|kbqwtcvzhymhpoelrnaxydifyb|kbqctcvzgumhpoalrnaxydifuj|kuqktcvzgsmhpoelrnaxydieuj|kbqwtcvzgsmvpozlrnaxydifmj|kbqwtcvzgsmhpojlraaxydiouj|kbqwtcvzgmmhpoelknaxydizuj|kbwwtcvzgsmhpoefrnaxydifij|kbqwucvzgsmhpoelvnahydifuj|kbqwtcvzpsmhpgelrqaxydifuj|kblqtcvzgsmhpoeirnaxydifuj|kbqwtcvzgsmhpovlrnabydifum|kbqwwcvzgsmhpoelrnaoydnfuj|kyqwdcvzgsmhpoelrnaxfdifuj|kbqftcvzgsmxpoelknaxydifuj|kbqwtsvzksmhpoelqnaxydifuj|kbqwtcvzgsmhplelrnauydifux|kbqytcvzgsmhpkelrnaxydefuj|kbqwtcvzgsmjjoelrlaxydifuj|kbqvtcvzgsmhpoelnnaxydafuj|kbqwtcvzgsjhioelrnaxpdifuj|kbqptcvpgsmhpoelrnaxydiful|kbqwjcazgimhpoelrnaxydifuj|kbqxtcvzgwmhpaelrnaxydifuj|kbqwtcezgsmhqoelrnaxydifub|kbqwtcvzgsmhooelynaxydifuf|kbqwtwvzgsmkpoelrnaxrdifuj|nbqwtcvugsmhpoelrnzxydifuj|kbvwqcvzgsmhpoelsnaxydifuj|kbqwtcyzjsmhpoelrnaxymifuj|kbqwtcvzgsmhpoclrnaxykzfuj|kbbwtcvzgsmhyodlrnaxydifuj|kbwwtcvzgsmytoelrnaxydifuj|kbmwtcczgpmhpoelrnaxydifuj|ubqwtcvzgsmmpoblrnaxydifuj|kbqwtcvzgrmhpoelrnaxnrifuj|kbqwhcvzgsmhpoelynaaydifuj|kbqwtcvzgsmtpoelrcpxydifuj|kdqwtchzgsmhpoelrmaxydifuj|qbqrncvzgsmhpoelrnaxydifuj|kbqwtcvzghshpoelrnaxodifuj|kbqwhcvzgsmhpoelknaxydiwuj|ebqwtcvzgsmhpoelrotxydifuj|kbqwacvzusmhpoelryaxydifuj|kbqwtcvggsmhpoelrnaxygifyj|kbqwtcvzgsmhpoelrnaxycwfuo|kzqwzcvzgsmhpoelrxaxydifuj|khqwtcvzgsmhpoelrnaxldifyj|kbqwtbtzgsmhpoelrnaxydifud|gbqwtcvzgqmhpoelrnaxydifrj|kbqdtqvzgwmhpoelrnaxydifuj|kbqwscvzgsmhpoelrpaxypifuj|kmqwtcdzgsmhpoelenaxydifuj|klqwtcvvgsmhpoelrfaxydifuj|kbuwtcvzgsmhpoelrtaxyuifuj|kbqwtcvrgomhpoelrnaxydijuj|kbqwtgvzgsmhzoelrnpxydifuj|kbqltcvzgsmhooeljnaxydifuj|kbqwtcvzgbmxpoelrnaxydivuj|kbqdtcmzgsmhpoelrnaxydmfuj|kbqwtcazgsmhpoplrnacydifuj|kbqztcvegsmhpoelrnvxydifuj|kbqwtcvzgsmhpoecrnaxydzfsj|kbqwtcvzgsmepoelrnaqydifuf|kbqwtcqzgsmhpoelrnoxydivuj|kbqwtcvzgsmhpoeylnaxydhfuj|kbqwtcvfgsmhpoelrnaxgdifyj|kbqwtcvzgsmhnbelrnaxyfifuj|kbqwtcvzgsmhpoelrnaxbdffmj|kwqwtcvogtmhpoelrnaxydifuj|kdqwtcvzggyhpoelrnaxydifuj|kbqwtuvzgtmhpoelrnaxydifxj|kbqctdvzcsmhpoelrnaxydifuj|kbqwtcvzgsmhpoblrniyydifuj|kbqwucvzzsmhpoelrnvxydifuj|kbqwtcvzgslzpoelrnaxydiruj|kbqwtdmzgsmhpwelrnaxydifuj|kbqwtcvzgsmhpoilrnaxqiifuj|kbqwtcvzgsmhpgelrnaxydisnj|kbdwtqvzgsmhpoelrnaxydivuj|kbqvtdvzgsmhpoelrjaxydifuj|kfqwtcvzgsmhpoeurnyxydifuj|kbqwtcvzgsmhpoglrnaxqkifuj|kbqwtcvrgsmhpoelrnajydifnj|xbqwpcvzgjmhpoelrnaxydifuj|kbqwtcvzgsmhpoelrdaxvdihuj|kbuwtcvzssmhpoklrnaxydifuj|kbqwtcvzgqmhpoelrnzxydifbj|kbqwtcvzgsmhsoeoknaxydifuj|kfqltcvzgsmhpoelrnaxydifnj|qbqwtsvzgsmhpoelrnaxodifuj|kbqwwevzgsmypoelrnaxydifuj|kbqwtcuzgimhpoelrnaxydffuj|kxqwlcvzgsmhpoelrnaxyrifuj|nbqwtcvzgsmhpoelryaxyiifuj|kbqwtcvzgsmhhoxlreaxydifuj|mbqwtcvzfsmxpoelrnaxydifuj|kbqwttvzgsmhpoeqrnaxidifuj|kbqwtcvzgamhpielrnaxyiifuj|rfqwtcvzgsmhpoelrnaxydifun|kbpwtqvzgsmbpoelrnaxydifuj|kbqwtcvzgsmhpoqlroaxydifua|hbqwtcvzksmhpoelrnaxydbfuj|kaqutcvzgsmhpoelrnaxydiiuj|kbqctcvzgsnhpoelrcaxydifuj|kbqwtnvzgsmhpoelrnaxydqfoj|kbqwtcvzhsmhpoelrnaxydifyb|ubqwtcvcgsmhooelrnaxydifuj|kbqwtcvrgsmhpoelrnaxtdivuj|kbqwtcvzgsmhplelrnmxydifaj|ebqwlcvzghmhpoelrnaxydifuj|hbqwtcvzgsmhpoelrnaqyeifuj|kbqstcvzgsmeprelrnaxydifuj|kbqwtcvogsthpoelrnnxydifuj|ybqwtcvzgdmhpoelrnaxydufuj|kbqutcvzgsmhpoelrnaxydifgx|kbqwtcvzgsmhpozlunadydifuj|kkqwtcvzgsmhpuefrnaxydifuj|kbqrtcvzgsmhpoelrnaxcdifuq|kbqwtcvzjsmupoelrnaxydiluj|kbqwmcvzgsuhpoelrnaxydifhj|kbqwfcvzgsmhpoelrnaxydkzuj|kbqatcvzgsdhpoeyrnaxydifuj|kbtwtcvzusmhpoelrxaxydifuj|kbqwtcwzgsmhpoelrnaxysofuj|kbqqtcvmgsmhpoevrnaxydifuj|kbqwjcvzgsmhpoelrnaxydhuuj|mbdwtcvzgsmhpoelqnaxydifuj|kbqwtcvlgsmhpoelrdaxydifaj|kbqwtcvzgsmmpoelrlaxydnfuj|kbqwtchfggmhpoelrnaxydifuj|kbqqtcvzgsyhpoelrnaxyoifuj|knqwtcvzqsmupoelrnaxydifuj|kdqdtcvzgsmhpoelrnaxydmfuj|kbqwtcvzgsmhptelrnawyhifuj|kbqwtcvzgrmhpoeqrnaxydifuw|kbnxtcvzgsmhpoelrnauydifuj|kbqwacvsgsmhpoelrnaxydifgj|kbqwtcvzgsmhpperrnaxydifuc|gbqwtcvzgsqhxoelrnaxydifuj|kbqwtcvzgsmhpoeljgaxydifwj|kbqktcvzgsmhpotlrnatydifuj|bbqwtcvzgsmhpoilrnaxydjfuj|kbqwecvdgsmhpoelrnaxypifuj|keqwtcvzgemhpotlrnaxydifuj|kbqptcvzgsmvpoelrnaxydixuj|kbqwbctzgsmhpoelrnaxydifup|kbqwtcvzgszhpbelrnzxydifuj|mbqwtcvtgsmhpoeyrnaxydifuj|kbqwtcvzgsmhqcelrhaxydifuj|kbqotcvzgsmhooelrnazydifuj|kbqwtcvzgsmhpoelmpaxyiifuj|kbqwtcvwgsmypoclrnaxydifuj|kbqwtcvsgskhpoelrnaxykifuj|kbqwtcvzgszvpoelrnwxydifuj|kbqwtcvzgsmhpoejonaxydrfuj|kbqwtcvzgsmhkoelrnazyqifuj|kbzwtzvzgsmhptelrnaxydifuj|kbqwtcdzgsmhptelrnaxydiduj|kbqwtcvzgamhpoelrnakyzifuj|kbqwtcvzgsmhpoeonnaxydifxj|kbqwtcvzgsmhpoeranaxydifej|kbqwscvzgsmhpoelunaxydimuj|cbqwtcvzgsmhpoelrdaxydefuj|vbqwtcjzgsmhpoelrnaxydifua|kmqwtcvzksmhpoeljnaxydifuj|kbqwtcvzgsmppojlrnasydifuj|kaqwtcvfgsmhpoelrnaxydiauj|khqwccvzgsmhpoelrnaxydifud|vbqwtcvzrsmhpoelrhaxydifuj|kuqwtcvzgsmhpoelgnaiydifuj|kbqwtcvzdsmhpbelvnaxydifuj|kbowtcvzgnmhpoelrfaxydifuj|kbqwtcvsgsmhfoejrnaxydifuj|kbqwtcvzgskhtoelrnxxydifuj|kbqwtcvzgtmhpoevrnaxydivuj|bbqptcgzgsmhpoelrnaxydifuj|kbqwtpvzgsmnpoelhnaxydifuj|kbqwtovzgsmmpoelrnaxydifuw|kbqwtcvzgsihpwelrnaxydsfuj|kbqwtcvzggmhpollrnaxydifsj|kbqwtcjzgsmhpoelrnaxyxifub|ebqwtcvzgsmzpoelrnaaydifuj|kbqwtcvzusmhpoelrnqxydijuj|obqwtcvzgsghpoelrnaxydifkj|kbrwtcvzmdmhpoelrnaxydifuj|kbqwtcvzxsmhpoblrnhxydifuj|kbqwacvzgsahpoelrnaxydiguj|kyqwtcvzgsmipoelrnlxydifuj|kbbwtcvzgsmhboelpnaxydifuj|kbqwtcvzgsmhpoelrnaxhdosuj|kbqwtgvzgxmhpoelrnaxyrifuj|pbqwtsvzgsmhpoelrnabydifuj|kbqrtcvzgsmhpsblrnaxydifuj|kbqwtcvzgsmhpoexrnaaycifuj|kbqxtcvzgsjhkoelrnaxydifuj|kbqwtcvzgsmhpxelrnaxydifby|lbxwtcvzgsmdpoelrnaxydifuj|kbqwtcczgsmhpoklrnzxydifuj|zbqwtcvzgsmhpoelrbaxydifui|krqwtcvzbsmhpoelrjaxydifuj|kbkwtcvzgsmhpoelrnaxydiacj|kbqwtcvzgszhpseprnaxydifuj|kbxwtcvzxsmhpoesrnaxydifuj|kbqwdcvzgsmhpoelrbaxygifuj|kbqwthkzgsmhhoelrnaxydifuj|klqwtchzgamhpoelrnaxydifuj|obqwtcvzgsvcpoelrnaxydifuj|kblwtcvzgsmhpoelrnanydifuw|kbqwtrvzgsmhpoelynaxydifug|kbqwtcvzgsmhcoelmnaxydkfuj|kbqwtcvzgsmhpotlqoaxydifuj|kaqatcvzgsmhpoelrnaxyiifuj|kbqttcvwgsmhpoelrnaxydifgj|kpqwtcvzgsmhpwelynaxydifuj|kbqwucvzgsmhpyelrnaxyxifuj|kbqwucvzgsmhprelrnaxyfifuj|kbqwthvzgsmhphelrnaxylifuj|kbqwtcvzosmhdoelrnaxwdifuj|kbqwtxvsgsphpoelrnaxydifuj|koqwtcvfghmhpoelrnaxydifuj|kbtwicvzpsmhpoelrnaxydifuj|kbawtcvzgsmhmoelrnaxyiifuj|kbqwtcvzgslhpbelrnaxydifuk|kbqttcvzgsmypoelrnaxydifua|kbqwtcvrgqmhpnelrnaxydifuj|kbqwtcvzghmhpoekpnaxydifuj|kbqwtcvzgsmupoelrnaxidifui|kbqwtcvzgsmhpbelrnaxrdifux"))
                .When(_ => WhenWeCalculateChecksum())
                .Then(_ => ThenTheChecksumIs(7134))
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
