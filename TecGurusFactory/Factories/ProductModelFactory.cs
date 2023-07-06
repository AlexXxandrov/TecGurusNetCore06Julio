using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusCommon.Domain;
using TecGurusCommon.Interfaces;
using TecGurusFactory.Interfaces;
using TecGurusModels;

namespace TecGurusFactory.Factories
{
    /// <summary>
    /// Esta capa utiliza a los Services(Common), y tambien es utilizada el ViewModel(Web)
    /// </summary>
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductModelFactory(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public List<ProductModel> GetAllProductsModel()
        {
            var products = _productService.GetProducts().ToList();

            //artesanalmente se haria:
            //List<ProductModel> ListProductModels = new List<ProductModel>();
            //foreach (var product in products)
            //{
            //    ProductModel productModel = new ProductModel();
            //    productModel.ProductId = product.ProductId;
            //    //..
            //    ListProductModels.Add(productModel);
            //}

            //con automapper

            var productsModel = _mapper.Map<List<ProductModel>>(products);
            return productsModel;
        }


        //Tarea Crear un Metodo en ProductModelFactory para regresar la lista de List<ProductModel> pero que contenga los datos de category y de product(join
        //el metodo nuevo se llamada ProductWithCategory)----Automapper no se usa por que quien une es el join de linq

        public void CreateProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            _productService.CreateProduct(product);
        }
    }
}
