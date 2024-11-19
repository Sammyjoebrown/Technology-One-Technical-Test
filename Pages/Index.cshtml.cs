using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Technology_One_Technical_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Testing displaying text on the web page that is set in the C# code
        public string Test { get; set; }
        public string Output { get; set; }
        public string Input { get; set; }
        public string ConversionType { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Test = "Hey - I'm made in the C# code!";
            Output = "";
        }

        public void OnGet()
        {
            // Nothing to auto-get
        }

        public void OnPost()
        {
            Input = Request.Form["Input"];
            ConversionType = Request.Form["ConversionType"];

            // Validation stages
            // Check if input can be parsed as float - else error
            // Determine if the input should be presented as a dollar or a regular integer decimal (toggle)
            // If number can be parsed as a float, parse as a string and find how many characters are before and after the decimal point
            // Set three arrays - one for big numbers (hundreds, thousands, millions), one for medium numbers (teens) and one for small numbers (ones)
            // Iterate through the string, adding the appropriate number to the output string
            // Set rules for after every hundred, there should be an and
            // If the number is a dollar amount, add the word dollars to the end, and cents for the decimal part
            // If the number is a regular number, add the point to the end if there is a decimal part 

            // A very rough outline of how I would approach the problem (it's only day 1 after all)

            string[] large_numbers = { "hundred", "thousand", "million" };
            string[] medium_ty_numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] medium_teen_numbers = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] small_numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (float.TryParse(Input, out float InputProcessing)) {

                Int64 Input_length = InputProcessing.ToString().Length;

                /*if (Input_processing.ToString().Contains(".")) {
                    string[] Input_split = Input_processing.ToString().Split(".");
                    string Input_dollars = Input_split[0];
                    string Input_cents = Input_split[1];

                    Output = "Number is a float - " + Input_dollars + " - Size - " + Input_length + " - Cents - " + Input_cents;
                } else {
                    Output = "Number is a float - " + Input_processing + " - Size - " + Input_length;
                }*/

                Output  = "Number is a float - " + InputProcessing + " - Size - " + Input_length + " - Type - " + ConversionType;

            } else {
                Output = "Number is not a float - " + InputProcessing + " - Size - " + InputProcessing.ToString().Length + " - Type - " + ConversionType;
            }

        }
    }
}
