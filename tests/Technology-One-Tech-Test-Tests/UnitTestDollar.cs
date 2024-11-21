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
                { "1234", "Output: ONE THOUSAND TWO HUNDRED AND THIRTY FOUR DOLLARS" },
                { "9999", "Output: NINE THOUSAND NINE HUNDRED AND NINETY NINE DOLLARS" },
                { "10000.99", "Output: TEN THOUSAND DOLLARS AND NINETY NINE CENTS" },
                { "1000000", "Output: ONE MILLION DOLLARS" },
                { "987654321.45", "Output: NINE HUNDRED AND EIGHTY SEVEN MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE DOLLARS AND FORTY FIVE CENTS" },
                { "1000000000", "Output: ONE BILLION DOLLARS" },
                { "900174389654321", "Output: NINE HUNDRED TRILLION ONE HUNDRED AND SEVENTY FOUR BILLION THREE HUNDRED AND EIGHTY NINE MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE DOLLARS" },
                { "1", "Output: ONE DOLLAR" },
                { "0.01", "Output: ZERO DOLLARS AND ONE CENT" },
                { "0.10", "Output: ZERO DOLLARS AND TEN CENTS" },
                { "0", "Output: ZERO DOLLARS" },
                { "123.45", "Output: ONE HUNDRED AND TWENTY THREE DOLLARS AND FORTY FIVE CENTS" },
                { "1000000000000", "Output: ONE TRILLION DOLLARS" },
                { "5000000000.99", "Output: FIVE BILLION DOLLARS AND NINETY NINE CENTS" },
                { "250000", "Output: TWO HUNDRED AND FIFTY THOUSAND DOLLARS" },
                { "75.25", "Output: SEVENTY FIVE DOLLARS AND TWENTY FIVE CENTS" },
                { "5000.50", "Output: FIVE THOUSAND DOLLARS AND FIFTY CENTS" },
                { "1234567890.12", "Output: ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION FIVE HUNDRED AND SIXTY SEVEN THOUSAND EIGHT HUNDRED AND NINETY DOLLARS AND TWELVE CENTS" },
                { "999999999999999.99", "Output: NINE HUNDRED AND NINETY NINE TRILLION NINE HUNDRED AND NINETY NINE BILLION NINE HUNDRED AND NINETY NINE MILLION NINE HUNDRED AND NINETY NINE THOUSAND NINE HUNDRED AND NINETY NINE DOLLARS AND NINETY NINE CENTS" },
                { "42", "Output: FORTY TWO DOLLARS" },

                { "Hello", "Input is not a decimal - Hello - Type - Dollar"},
                { "Hello Technology One", "Input is not a decimal - Hello Technology One - Type - Dollar"},
                { "1234ty", "Input is not a decimal - 1234ty - Type - Dollar" },
                { "$100", "Input is not a decimal - $100 - Type - Dollar" },
                { "100.00.00", "Input is not a decimal - 100.00.00 - Type - Dollar" },
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
