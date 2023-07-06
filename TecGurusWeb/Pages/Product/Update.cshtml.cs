using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TecGurusWeb.Pages.Product
{
    public class UpdateModel : PageModel
    {
        public void OnGet(int Id)
        {
            //Logica para recuperar el producto por Id llamara a -> Factory(consume Service y tranforma de entidad a Model)-> ProductService regresa un Product -> EFRepository (GetById)
        }
    }
}
