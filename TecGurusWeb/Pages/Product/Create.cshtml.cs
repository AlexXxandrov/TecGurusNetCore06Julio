using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecGurusFactory.Factories;
using TecGurusFactory.Interfaces;
using TecGurusModels;

namespace TecGurusWeb.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryModelFactory _categoryModelFactory;
        private readonly IProductModelFactory _productModelFactory;
        public CreateModel(ICategoryModelFactory categoryModelFactory,
            IProductModelFactory productModelFactory)
        {
            _categoryModelFactory = categoryModelFactory;
            _productModelFactory = productModelFactory;
        }

        #region
        [BindProperty]
        public ProductModel Product { get; set; }

        public List<CategoryModel> Categories { get; set; }

        #endregion

        public void OnGet()
        {
            SetCategories();
        }

        public IActionResult OnPost()
        {
            //Validara el Model.State si cumple con todas los Anotaciones si no muestra los mensajes en la pantalla
            var errores = ModelState.Values.Select(s => s.Errors);
            //Excluir la propiedad para que no forme parte de la validacion del modelstate
            ModelState.Remove("CategoryName");
            if (!ModelState.IsValid)
            {
                SetCategories();
                return Page();
            }
            else
            {
                //Codigo de Inserción
                _productModelFactory.CreateProduct(Product);
            }

            return RedirectToPage("/Product/Index");

        }


        private void SetCategories()
        {
            Categories = _categoryModelFactory.GetAllCategoriesModel();
        }


    }
}
