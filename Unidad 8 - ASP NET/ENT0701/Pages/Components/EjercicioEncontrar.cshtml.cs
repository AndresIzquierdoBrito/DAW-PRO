using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioEncontrarModel : PageModel
    {
        private readonly ILogger<EjercicioEncontrarModel> _logger;

        public readonly BikeStoresDB Data;

        public EjercicioEncontrarModel(BikeStoresDB data)
        {
            Data = data;
        }

        public void OnGet()
        {
        }
    }
}
