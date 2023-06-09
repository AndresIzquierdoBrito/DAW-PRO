using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioBrandReportModel : PageModel
    {
        private readonly ILogger<EjercicioBrandReportModel> _logger;

        public readonly BikeStoresDB Data;

        public EjercicioBrandReportModel(BikeStoresDB data)
        {
            Data = data;
        }

        public void OnGet()
        {
        }
    }
}
