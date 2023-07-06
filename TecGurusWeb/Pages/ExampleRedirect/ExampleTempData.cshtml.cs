using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TecGurusWeb.Pages.ExampleRedirect
{
    public class ExampleTempDataModel : PageModel
    {
        [TempData]
        public string Nombre { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Tu nombre es: " + Nombre;
        }
    }
}
