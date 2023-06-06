using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]

    public class EjercicioSeleccionModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
