using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Technology_One_Technical_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Output { get; set; }
        public string Input { get; set; }
        public string ConversionType { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
            string[] large_numbers = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion" };
            string[] medium_ty_numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] medium_teen_numbers = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] small_numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (decimal.TryParse(Input, out decimal InputProcessing)) {
                
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
                            if (InputBeforePointArray[i][j] > 0) { // If the number in the hundreds place is not 0 - if it is, ignore
                                Output += small_numbers[InputBeforePointArray[i][j] - 1] + " " + large_numbers[0] + " and ";
                            }
                        } 
                        else if (InputBeforePointArray[i].Length >= 2 && j == InputBeforePointArray[i].Length - 2) {
                            // Teens and Tys case
                            if (InputBeforePointArray[i][j] == 1) { // If first number is 1, it's a teen number
                                Output += medium_teen_numbers[InputBeforePointArray[i][j + 1]] + " ";
                                break; // Break here because numbers 2 and 3 in the triplet are processed as a teen number
                            } 
                            else if (InputBeforePointArray[i][j] > 1) {
                                // Tens
                                Output += medium_ty_numbers[InputBeforePointArray[i][j] - 2] + " ";
                            }
                        } 
                        else if (InputBeforePointArray[i].Length >= 1 && j == InputBeforePointArray[i].Length - 1) {
                            // Ones case
                            if (InputBeforePointArray[i][j] > 0) {
                                Output += small_numbers[InputBeforePointArray[i][j] - 1] + " ";
                            }
                        }
                    }

                    // Each finished processed triplet should have a large number (unless it's the last one)
                    if (i < InputBeforePointArray.Length - 1 && i < large_numbers.Length) {
                        Output += large_numbers[InputBeforePointArray.Length - 1 - i] + " ";
                    }
                }

                if (ConversionType == "Dollar") {
                    Output += "Dollars";
                    if (InputAfterPointLength > 0) {
                        Output += " and ";
                    }
                } 

                // After decimal point (implementing a rounding system for dollar conversion and keeping it regular for number conversion)
                if (InputAfterPointLength > 0) {
                    if (ConversionType == "Dollar") {
                        // Round to two decimal places for dollar conversion
                        decimal roundedDecimal = (decimal)(Math.Round(InputProcessing - (decimal)InputProcessing, 2) * 100); // Needs to be decimal not int to fix Int32 size constraint bug
                        int cents = (int)roundedDecimal;

                        // Cents into tens and ones for rounding (common & efficient for finance)
                        int tens = cents / 10;
                        int ones = cents % 10;

                        if (tens == 1) {
                            // Teens case
                            Output += medium_teen_numbers[ones] + " "; // Teens deals with both tens and ones
                        } else {
                            if (tens > 1) {
                                Output += medium_ty_numbers[tens - 2] + " "; // Tys
                            }
                            if (ones > 0) {
                                Output += small_numbers[ones - 1] + " "; // Ones
                            }
                        }
                        Output += "cents";
                    } 
                    else if (ConversionType == "Number") {
                        // General number conversion uses only small numbers after the decimal point
                        Output += "point ";
                        foreach (char digit in InputAfterPoint) {
                            if (digit >= '1' && digit <= '9') {
                                Output += small_numbers[digit - '1'] + " ";
                            } else if (digit == '0') {
                                Output += "zero ";
                            }
                        }
                    }
                }

                Output = Output.ToUpper();
                Output = "Output: " + Output;
            } else {
                Output = "Input is not a decimal - " + InputProcessing + " - Size - " + InputProcessing.ToString().Length + " - Type - " + ConversionType;
            }

        }
    }
}
