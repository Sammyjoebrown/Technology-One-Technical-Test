using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Technology_One_Tech_Test.Logic;

namespace Technology_One_Technical_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public required string Output { get; set; }
        public required string Input { get; set; }
        public required string ConversionType { get; set; }

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
            if (Request.Form["Input"] == "" || Request.Form["ConversionType"] == "") {
                Output = "Please enter a number and select a conversion type";
                return;
            }
            else {
                Input = Request.Form["Input"].FirstOrDefault() ?? string.Empty;
                ConversionType = Request.Form["ConversionType"].FirstOrDefault() ?? string.Empty;
            }
            
            // Program logic needed to be separated to run both the app and the tests
            Output = Converter.Convert(Input, ConversionType);

        }
    }
}
