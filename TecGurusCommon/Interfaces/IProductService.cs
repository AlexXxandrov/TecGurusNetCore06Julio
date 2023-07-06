using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusCommon.Domain;

namespace TecGurusCommon.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);
    }
}
