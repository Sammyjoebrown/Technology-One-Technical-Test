using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Technology_One_Technical_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Testing displaying text on the web page that is set in the C# code
        public string Test { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            // Initialize the Test property
            Test = "Hello";
        }

        public void OnGet()
        {
            
        }
    }
}
