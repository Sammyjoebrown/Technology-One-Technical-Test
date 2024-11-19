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
            // If the number is a dollar amount, add the word dollars to the end, and cents to the very end for the decimal part (should be done after calculation)
            // If the number is a regular number, add the point to the end if there is a decimal part (should be done after calculation)

            // A very rough outline of how I would approach the problem (it's only day 1 after all)
            string[] large_numbers = { "hundred", "thousand", "million", "billion", "trillion" };
            string[] medium_ty_numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] medium_teen_numbers = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] small_numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (float.TryParse(Input, out float InputProcessing)) {
                
                // Get length of input
                int Input_length = InputProcessing.ToString().Length;
                string InputBeforePoint;
                int InputBeforePointLength;
                string InputAfterPoint;
                int InputAfterPointLength;

                // If input contains . , split into parts
                if (InputProcessing.ToString().Contains(".")) {
                    string[] InputSplit = InputProcessing.ToString().Split(".");
                    InputBeforePoint = InputSplit[0];
                    InputBeforePointLength = InputBeforePoint.Length;
                    InputAfterPoint = InputSplit[1];
                    InputAfterPointLength = InputAfterPoint.Length;
                } 
                else {
                    InputBeforePoint = InputProcessing.ToString();
                    InputBeforePointLength = InputBeforePoint.Length;
                    InputAfterPoint = "";
                    InputAfterPointLength = 0;
                }

                int[][] InputBeforePointArray = new int[(int)Math.Ceiling(InputBeforePointLength / 3.0)][];

                int tripletIndex = 0;
                
                // Split the before point into parts of 3 numbers each
                for (int i = InputBeforePointLength; i > 0; i-=3) {
                    int index = Math.Max(0, i - 3);
                    string triplet = InputBeforePoint.Substring(index, i - index);

                    int[] tripletArray = new int[triplet.Length];
                    for (int j = 0; j < triplet.Length; j++) {
                        tripletArray[j] = int.Parse(triplet[j].ToString());
                    }
                    InputBeforePointArray[tripletIndex] = tripletArray;

                    tripletIndex++;
                }
                // Array needs to be reversed to be in the correct order (which the number was inputted in)
                Array.Reverse(InputBeforePointArray);

                for (int i = 0; i < InputBeforePointArray.Length; i++) {
                    for (int j = 0; j < InputBeforePointArray[i].Length; j++) {
                        if (InputBeforePointArray[i].Length == 3 && j == 0) {
                            // Hundreds case
                            Output += InputBeforePointArray[i][j] + " " + large_numbers[j];
                        }
                        else if (InputBeforePointArray[i].Length == 2) {
                            // Tens case
                            if (j == 0) {

                                if (InputBeforePointArray[i][j] == 1) {
                                    Output += medium_teen_numbers[j];
                                }
                                else if (InputBeforePointArray[i][j] > 1) {
                                    Output += medium_ty_numbers[j];
                                }

                                Output += medium_ty_numbers[j];
                            }
                            else {
                                Output += small_numbers[j];
                            }
                        }
                        else if (InputBeforePointArray[i].Length == 1) {
                            // Ones case
                            Output += small_numbers[j];
                        }
                    }
                }

                Output = "Hello! ";
                for (int i = 0; i < InputBeforePointArray.Length; i++)
                {
                    Output += "[";
                    for (int j = 0; j < InputBeforePointArray[i].Length; j++)
                    {
                        Output += InputBeforePointArray[i][j];
                        if (j < InputBeforePointArray[i].Length - 1)
                        {
                            Output += ", ";
                        }
                    }
                    Output += "]";
                    if (i < InputBeforePointArray.Length - 1)
                    {
                        Output += ", ";
                    }
                }


            } else {
                Output = "Number is not a float - " + InputProcessing + " - Size - " + InputProcessing.ToString().Length + " - Type - " + ConversionType;
            }

        }
    }
}
