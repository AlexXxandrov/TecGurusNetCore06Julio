using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TecGurusWeb.Pages.ExampleRedirect
{
    public class QueryStringModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(int Id)
        {
            Message = "Tu Id Ingresado es: " + Id.ToString();
        }
    }
}
