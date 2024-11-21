using Xunit;
using Xunit.Sdk;

namespace Technology_One_Tech_Test_Tests
{
    public class UnitTestDollar
    {
        [Fact]
        public void DollarTest()
        {
            // A dictionary of test cases - first is the input, second is the expected output
            Dictionary<string, string> TestCases = new Dictionary<string, string>
            {
                { "1234", "ONE THOUSAND TWO HUNDRED AND THIRTY FOUR DOLLARS" },
                { "9999", "NINE THOUSAND NINE HUNDRED AND NINETY NINE DOLLARS" },
                { "10000.99", "TEN THOUSAND DOLLARS AND NINETY NINE CENTS" },
                { "1000000", "ONE MILLION DOLLARS" },
                { "987654321.45", "NINE HUNDRED AND EIGHTY SEVEN MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE DOLLARS AND FORTY FIVE CENTS" },
                { "1000000000", "ONE BILLION DOLLARS" },
                { "100078912347890000", "ONE HUNDRED QUADRILLION SEVENTY EIGHT TRILLION NINE HUNDRED AND NINETY ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION SEVEN HUNDRED AND EIGHTY NINE THOUSAND DOLLARS" },
                { "1", "ONE DOLLAR" },
                { "0.01", "ONE CENT" },
                { "0.10", "TEN CENTS" },
                { "0", "ZERO DOLLARS" },
                { "123.45", "ONE HUNDRED AND TWENTY THREE DOLLARS AND FORTY FIVE CENTS" },
                { "1000000000000", "ONE TRILLION DOLLARS" },
                { "5000000000.99", "FIVE BILLION DOLLARS AND NINETY NINE CENTS" },
                { "250000", "TWO HUNDRED AND FIFTY THOUSAND DOLLARS" },
                { "75.25", "SEVENTY FIVE DOLLARS AND TWENTY FIVE CENTS" },
                { "5000.50", "FIVE THOUSAND DOLLARS AND FIFTY CENTS" },
                { "1234567890.12", "ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION FIVE HUNDRED AND SIXTY SEVEN THOUSAND EIGHT HUNDRED AND NINETY DOLLARS AND TWELVE CENTS" },
                { "999999999999999.99", "NINE HUNDRED AND NINETY NINE TRILLION NINE HUNDRED AND NINETY NINE BILLION NINE HUNDRED AND NINETY NINE MILLION NINE HUNDRED AND NINETY NINE THOUSAND NINE HUNDRED AND NINETY NINE DOLLARS AND NINETY NINE CENTS" },
                { "42", "FORTY TWO DOLLARS" }
            };

            foreach (KeyValuePair<string, string> TestCase in TestCases)
            {
                string Input = TestCase.Key;
                string ExpectedOutput = TestCase.Value;
                string Output = Technology_One_Tech_Test.Logic.Converter.Convert(Input, "Dollar");

                Assert.Equal(ExpectedOutput, Output);
            }
        }
    }
}
