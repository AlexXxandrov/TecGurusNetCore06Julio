using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusCommon.Domain;
using TecGurusCommon.Interfaces;

namespace TecGurusCommon.Services
{
    /// <summary>
    /// Esta capa utiliza el Repository(Infraestructure) , y expone sus metodos para que los utilice Factory
    /// </summary>
    public class ProductService : IProductService
    {

        private readonly IEFRepository<Product> _productRepository;

        public ProductService(IEFRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }


        public void CreateProduct(Product product)
        {
            var created = _productRepository.Create(product);
            _productRepository.Save();
        }
    }
}
