# Technology One Technical Test
### Samuel Brown's submission for the Technology One Technical Test, issued on November 18th, 2024, by Mr. Tyler Sanders.
### Position - Graduate Software Developer - 2025 (Engineering Candidate)

## Introduction
The 'Numbers to Words' Web App is an application which uses C# and Microsoft's ASP .NET development framework. The application accepts an input on the interface from a user, and if the input is a number, converts it to words, and has support for converting into both regular numeric, and Australian Dollar amounts.

### This Project Includes:
- A C# Microsoft ASP .NET web application, which can be ran by downloading the full Microsoft .NET framework and running the command 'dotnet watch run'
- Separate Front-End (HTML, Bootstrap CSS, JavaScript inside the 'Pages' directory) and Back-End Code (C# back-end inside the Pages & Logic directories)
- Test files & cases (as specified in the task) to test the 'Numbers to Words' converter for both numbers and dollars using XUnit Testing (which can be ran using 'dotnet test')
- A self-contained executable (as specified in the task) for simplified running on Windows computers, as it does not require .NET to be installed.

### Tools and Frameworks
- Language: C#
- Framework: .NET 9.0
- UI: HTML, styled with Bootstrap
- Testing: xUnit

### Why I Chose What I Chose:
 - C# & ASP .NET: ASP .NET is a large C# framework with direct support for web apps through the 'Razor pages' default configuration. The reason I chose it was because of a huge support base & community, a range of built-in commands and features for developing additional features & testing, and also as a general package & use-case, it reminds me a lot of flask, which is my preferred web development framework for my favourite language, Python :)

 - Front End: I've been using Bootstrap for all my web development projects for the past 5 years. Whilst Bootstrap is built into the ASP .NET Razor Pages project for formatting the front-end, it was very simplistic and needed some additional development to make a front-end that was both nice to look at, and addresses the key task functionality.

 - XUnit Testing: XUnit Testing was my choice of testing solution, as it is the largest & has direct integrations with dotnet. After solving some package version mismatch issues, this package is very similar to the previous testing solutions I have used - PyUnitTest for Python projects, and Jest for other raw JavaScript web applications.

 ####  My Approach to Creating the Back-End Logic: 
 I began with a structured plan for my 'Numbers to Words' conversion logic. Initially, I outlined validation stages, including parsing the input as a float (which was later changed to parsing as a decimal due to issues with floating point accuracy), determining if the conversion should be in dollars or numbers, and segmenting the input into 'triplets' for processing (as words are assigned to numbers in groups of three). Using arrays for large, medium, and small numbers, I designed logic to iterate through the input string, and if it can be parsed as a decimal, separate the number into multiple nested arrays of three elements, and then mapping numeric values to their corresponding words. Key rules, such as appending "and" after hundreds and distinguishing cents for dollar amounts, were also created & refined over time.


In implementation, I refined this approach to dynamically handle large numbers, prevent redundant outputs (e.g., "ONE MILLION THOUSAND HUNDRED"), and efficiently process both integer and decimal components. Modularity can be seen through separating the back-end logic into a separate function, so the web app and the testing suite can use the same code, and changed can be made efficiently, while features like rounding cents and formatting outputs in uppercase ensured the outputs were of the standard highlighted in the task criteria.


## How to Run the Application

### Running the .exe
1. Download the repository as a ZIP file and extract it.
2. Navigate to the path: "Technology-One-Technical-Test\bin\Release\net9.0\win-x64\publish\"
3. Double-click on `Technology-One-Technical-Test.exe` to run the application.
4. The .exe file should open the command prompt, which will show the application is running on a localhost instance. Copy the localhost link, and paste into a browser to use the application.
    - Ensure the machine is running Windows 10 or 11
    - No additional dependencies (such as the .NET framework) are required, as the executable is self-contained.

    Running the Application in a .NET Environment


### Running the Application in a .NET Environment
#### Prerequisites:
- .NET SDK 9.0 or later installed on your machine. [.NET 9.0 SDK available here](https://dotnet.microsoft.com/download).

1. Clone the repository:
```bash
git clone https://github.com/Sammyjoebrown/Technology-One-Technical-Test
cd Technology-One-Technical-Test
```
OR, clone the repository using Visual Studio / VS Code's build-in GitHub functionalities [using this URL](https://github.com/Sammyjoebrown/Technology-One-Technical-Test) (If cloning to Visual Studio, select the 'Open with Visual Studio' button beneath the green code dropdown)

2. Once the repository has been cloned, open it in an IDE / Code Editor of your choice (for example, VS Code), open a Command Prompt instance, and run the application using 
```cs
dotnet build
dotnet watch run
```
This will build and run the application, and will automatically open the application in a new tab in your default opened browser. If this does not happen, see the console where a localhost & port link will be available. Copy and paste that into a browser without stopping the above command. 
3. To stop the application from running, click the terminal instance and press "CTRL + C" to force exit.


### Running the Tests for the Application
#### Please note - see 'Test_Results.png' for a screenshot of all test results - all of which are successful.
#### Prerequisites:
- .NET SDK 9.0 or later installed on your machine. [.NET 9.0 SDK available here](https://dotnet.microsoft.com/download).

1. Navigate to the repository folder:
```bash
cd Technology-One-Technical-Test
```
2. Run the tests:
```cs
dotnet test
```
3. Observe the outputs of the tests in the console instance (seen in the screenshot). All test cases validate the correctness of the "Number to Words" conversion logic.

Test case examples for numbers:
| Input    | Output |
| -------- | ------- |
| 123.45  | ONE HUNDRED AND TWENTY THREE POINT FOUR FIVE    |
| 1000000 | ONE MILLION     |
| 0    | ZERO    |

Test case examples for dollars:
| Input    | Output |
| -------- | ------- |
| 1234.56  | ONE THOUSAND TWO HUNDRED AND THIRTY FOUR DOLLARS AND FIFTY SIX CENTS    |
| 987.654321 | NINE HUNDRED AND EIGHTY SEVEN DOLLARS AND SIXTY SIX CENTS     |
| 0    | ZERO DOLLARS   |
| 0.19    | ZERO DOLLARS AND NINETEEN CENTS    |


## Conclusion
This project demonstrates my ability to:
- Analyse and solve complex problems
- Develop & test code using multiple tools in multiple languages
- Write clean code that can be expanded, refined, maintained, and build upon



Thank you for reviewing my submission - I really enjoyed putting together my .NET 'Numbers to Words' web app.

Please feel free to contact me with any questions, feedback, issues, or information @ sammyjoebrownme@gmail.com