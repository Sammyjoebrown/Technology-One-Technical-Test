using Microsoft.VisualBasic;

namespace Technology_One_Tech_Test.Logic
{
    public class Converter
    {
        public static string Convert(string Input, string ConversionType) 
        {
            string Output = "";
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
                    bool hasZeroValue = true;
                    bool addAnd = false; // Adding ands dynamically & programatically
                    for (int j = 0; j < InputBeforePointArray[i].Length; j++) {
                        if (InputBeforePointArray[i][j] != 0) { // Fixes an issue where 1000000000 would hit all conditions for large numbers and output 'ONE BILLION MILLION THOUSAND'
                            hasZeroValue = false;
                        }

                        if (InputBeforePointArray[i].Length == 3 && j == 0) {
                            // Hundreds case
                            if (InputBeforePointArray[i][j] > 0) { // If the number in the hundreds place is not 0 - if it is, ignore
                                Output += small_numbers[InputBeforePointArray[i][j] - 1] + " " + large_numbers[0] + " ";
                                addAnd = true;
                            }
                        } 
                        else if (InputBeforePointArray[i].Length >= 2 && j == InputBeforePointArray[i].Length - 2) {
                            // Teens and Tys case
                            if (InputBeforePointArray[i][j] == 1) { // If first number is 1, it's a teen number
                                if (addAnd) {
                                    Output += "and ";
                                    addAnd = false; // Add an 'and' once per triplet then reset for next one
                                }
                                Output += medium_teen_numbers[InputBeforePointArray[i][j + 1]] + " ";
                                break; // Break here because numbers 2 and 3 in the triplet are processed as a teen number
                            } 
                            else if (InputBeforePointArray[i][j] > 1) {
                                // Tens
                                if (addAnd) {
                                    Output += "and ";
                                    addAnd = false; // Add an 'and' once per triplet then reset for next one
                                }
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
                    if (!hasZeroValue && i < InputBeforePointArray.Length - 1 && i < large_numbers.Length) {
                        Output += large_numbers[InputBeforePointArray.Length - 1 - i] + " ";
                    }
                }

                if (ConversionType == "Dollar") {
                    if (Math.Truncate(InputProcessing) == 1) {
                        Output += "Dollar";
                    } 
                    else if (Math.Truncate(InputProcessing) > 1) {
                        Output += "Dollars";
                    }
                    else if (Math.Truncate(InputProcessing) < 1) {
                        Output += "Zero Dollars";
                    }

                    if (InputAfterPointLength > 0 && InputAfterPoint != "00") {
                        Output += " and ";
                    }
                } 

                if (ConversionType == "Number") {
                    if (Math.Truncate(InputProcessing) < 1) {
                        Output += "Zero ";
                    }
                }

                // After decimal point (implementing a rounding system for dollar conversion and keeping it regular for number conversion)
                if (InputAfterPointLength > 0) {
                    if (ConversionType == "Dollar") {
                        // Round to two decimal places for dollar conversion
                        decimal fractionalPart = InputProcessing - Math.Truncate(InputProcessing); // Get the fractional part of the number by subtracting the whole number
                        int cents = (int)Math.Round(fractionalPart * 100); // Fixing a bug which does not process the cents correctly for >billion numbers


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
                        if (cents == 1) {
                            Output += "Cent";
                        } else if (cents > 1) {
                            Output += "Cents";
                        }
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
                Output = Output.Trim();
            } else {
                Output = "Input is not a decimal - " + Input + " - Type - " + ConversionType;
            }
            return Output;
        }
    }
}