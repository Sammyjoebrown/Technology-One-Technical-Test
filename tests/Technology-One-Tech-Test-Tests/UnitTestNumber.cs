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
                { "1234", "ONE THOUSAND TWO HUNDRED AND THIRTY FOUR" },
                { "9999", "NINE THOUSAND NINE HUNDRED AND NINETY NINE" },
                { "10000.99", "TEN THOUSAND POINT NINE NINE" },
                { "1000000", "ONE MILLION" },
                { "987654321.45", "NINE HUNDRED AND EIGHTY SEVEN MILLION SIX HUNDRED AND FIFTY FOUR THOUSAND THREE HUNDRED AND TWENTY ONE POINT FOUR FIVE" },
                { "1000000000", "ONE BILLION" },
                { "100078912347890000", "ONE HUNDRED QUADRILLION SEVENTY EIGHT TRILLION NINE HUNDRED AND NINETY ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION SEVEN HUNDRED AND EIGHTY NINE THOUSAND" },
                { "1", "ONE" },
                { "0.01", "POINT ZERO ONE" },
                { "0.10", "POINT ONE ZERO" },
                { "0", "ZERO" },
                { "123.45", "ONE HUNDRED AND TWENTY THREE POINT FOUR FIVE" },
                { "1000000000000", "ONE TRILLION" },
                { "5000000000.99", "FIVE BILLION POINT NINE NINE" },
                { "250000", "TWO HUNDRED AND FIFTY THOUSAND" },
                { "75.25", "SEVENTY FIVE POINT TWO FIVE" },
                { "5000.50", "FIVE THOUSAND POINT FIVE ZERO" },
                { "1234567890.12", "ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION FIVE HUNDRED AND SIXTY SEVEN THOUSAND EIGHT HUNDRED AND NINETY POINT ONE TWO" },
                { "999999999999999.99", "NINE HUNDRED AND NINETY NINE TRILLION NINE HUNDRED AND NINETY NINE BILLION NINE HUNDRED AND NINETY NINE MILLION NINE HUNDRED AND NINETY NINE THOUSAND NINE HUNDRED AND NINETY NINE POINT NINETY NINE" },
                { "42", "FORTY TWO" },

                { "Hello", "Input is not a decimal - Hello - Type - Number"},
                { "Hello Technology One", "Input is not a decimal - Hello Technology One - Type - Number"},
                { "1234ty", "Input is not a decimal - 1234ty - Type - Number" },
                { "$100", "Input type is not a decimal - $100 - Type - Number" },
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
