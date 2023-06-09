using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioAnadirStaffModel : PageModel
    {
        private readonly ILogger<EjercicioAnadirStaffModel> _logger;

        public readonly BikeStoresDB Data;

        public EjercicioAnadirStaffModel(BikeStoresDB data)
        {
            Data = data;
        }

        public void OnGet()
        {
        }
    }
}
