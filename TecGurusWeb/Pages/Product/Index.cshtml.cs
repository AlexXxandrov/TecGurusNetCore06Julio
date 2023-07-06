using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecGurusFactory.Interfaces;
using TecGurusModels;

namespace TecGurusWeb.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductModelFactory _productModelFactory;

        public IndexModel(IProductModelFactory productModelFactory)
        {
            _productModelFactory = productModelFactory;
        }

        #region Properties
        public List<ProductModel> ListProductModel { get; set; }

        #endregion


        public void OnGet()
        {
            ListProductModel= _productModelFactory.GetAllProductsModel();
        }
    }
}
