using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusModels;

namespace TecGurusFactory.Interfaces
{
    public interface IProductModelFactory
    {
        List<ProductModel> GetAllProductsModel();
        void CreateProduct(ProductModel productModel);
    }
}
