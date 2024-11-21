using Xunit;

namespace Technology_One_Tech_Test_Tests
{
    public class UnitTestNumber
    {
        [Fact]
        public void NumberTest()
        {
            Dictionary<string, string> TestCases = new Dictionary<string, string>
            {
                { "1234", "Output: ONE THOUSAND TWO HUNDRED AND THIRTY FOUR" },
                { "9999", "Output: NINE THOUSAND NINE HUNDRED AND NINETY NINE" },
                { "10000.99", "Output: TEN THOUSAND POINT NINE NINE" },
                { "1000000", "Output: ONE MILLION" },
                { "987654321.45", "Output: NINE HUNDRED AND EIGHTY SEVEN MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE POINT FOUR FIVE" },
                { "1000000000", "Output: ONE BILLION" },
                { "900174389654321.74", "Output: NINE HUNDRED TRILLION ONE HUNDRED AND SEVENTY FOUR BILLION THREE HUNDRED AND EIGHTY NINE MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE POINT SEVEN FOUR" },
                { "1", "Output: ONE" },
                { "0.01", "Output: ZERO POINT ZERO ONE" },
                { "0.10", "Output: ZERO POINT ONE ZERO" },
                { "0", "Output: ZERO" },
                { "123.45", "Output: ONE HUNDRED AND TWENTY THREE POINT FOUR FIVE" },
                { "1000000000000", "Output: ONE TRILLION" },
                { "5000000000.99", "Output: FIVE BILLION POINT NINE NINE" },
                { "250000", "Output: TWO HUNDRED AND FIFTY THOUSAND" },
                { "75.25", "Output: SEVENTY FIVE POINT TWO FIVE" },
                { "5000.50", "Output: FIVE THOUSAND POINT FIVE ZERO" },
                { "1234567890.12", "Output: ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION FIVE HUNDRED AND SIXTY SEVEN THOUSAND EIGHT HUNDRED AND NINETY POINT ONE TWO" },
                { "999999999999999.99", "Output: NINE HUNDRED AND NINETY NINE TRILLION NINE HUNDRED AND NINETY NINE BILLION NINE HUNDRED AND NINETY NINE MILLION NINE HUNDRED AND NINETY NINE THOUSAND NINE HUNDRED AND NINETY NINE POINT NINE NINE" },
                { "42", "Output: FORTY TWO" },

                { "Hello", "Input is not a decimal - Hello - Type - Number"},
                { "Hello Technology One", "Input is not a decimal - Hello Technology One - Type - Number"},
                { "1234ty", "Input is not a decimal - 1234ty - Type - Number" },
                { "$100", "Input is not a decimal - $100 - Type - Number" },
                { "100.00.00", "Input is not a decimal - 100.00.00 - Type - Number" },
            };

            foreach (KeyValuePair<string, string> TestCase in TestCases)
            {
                string Input = TestCase.Key;
                string ExpectedOutput = TestCase.Value;
                string Output = Technology_One_Tech_Test.Logic.Converter.Convert(Input, "Number");

                Assert.Equal(ExpectedOutput, Output);
            }
        }
    }
}
