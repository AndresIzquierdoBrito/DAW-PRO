using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly BikeStoresDB Data;

        public IndexModel(BikeStoresDB data)
        {
            Data = data;
        }

        public void OnGet()
        {

        }
    }
}