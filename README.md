# Technology-One-Technical-Test
Samuel Brown's submission for the Technology One Technical Test, issued on the 18th November by Mr. Tyler Sanders

I want to create the 'Numbers to Words' web app using C# and Microsoft's '.NET' web development framework.
I will use the Model View Controller web app layout to create this, and will try to abide by best coding practices.

Firstly, I created a private GitHub repository, and synced to my Visual Studio Code (as specified in the test task sheet)
Next, I created my index.html using Bootstrap for decoration (as I absolutely love bootstrap and both me and my dad have used it for almost 5 years)
Once the index.html looks good and is ready to be developed, I ran the following commands to make a new .NET web app:

dotnet new
dotnet new webapp
This created the files and folders necessary to make a standard Microsoft .NET web application (all default and requiring customisation)
Always have to check the application is running correctly by using dotnet run (all is fine)
Now I am integrating the existing index.html I made into the 'Pages' folder of my newly created .NET web app


// Validation stages - Sam's Initial Plan
            // Check if input can be parsed as float - else error
            // Determine if the input should be presented as a dollar or a regular integer decimal (toggle)
            // If number can be parsed as a float, parse as a string and find how many characters are before and after the decimal point
            // Set three arrays - one for big numbers (hundreds, thousands, millions), one for medium numbers (teens) and one for small numbers (ones)
            // Iterate through the string, adding the appropriate number to the output string
            // Set rules for after every hundred, there should be an and
            // If the number is a dollar amount, add the word dollars to the end, and cents to the very end for the decimal part (should be done after calculation)
            // If the number is a regular number, add the point to the end if there is a decimal part (should be done after calculation)

            // A very rough outline of how I would approach the problem (it's only day 1 after all)


Technology-One-Technical-Test\bin\Release\net9.0\win-x64\publish\Technology-One-Technical-Test.exe Is the path of the executable