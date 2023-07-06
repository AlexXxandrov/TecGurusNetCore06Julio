using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecGurusWeb.ExampleDI;

namespace TecGurusWeb.Pages.Course
{
    //RazorPage -> Patron de Desarrollo MV V M
    //(Model View , View, Model)  -Codebehind- ViewModel
    public class IndexModel : PageModel
    {

        //Inyeccion de dependencias
        private readonly IDiasService _diasService;
        public IndexModel(IDiasService diasService)
        {
            _diasService = diasService;
        }

        /// <summary>
        /// Modelo son todas las propiedades establecidas
        /// en esta clase
        /// recuperadas o enviadas a la vista
        /// </summary>
        public List<Dias> Dias { get; set; }

        public void OnGet()
        {
            Dias = _diasService.GetDias();
        }
    }
}
