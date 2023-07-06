using AutoMapper;
using TecGurusCommon.Domain;
using TecGurusModels;

namespace TecGurusWeb.Utils
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {
            //Entity to Model

            CreateMap<Product, ProductModel>();
            CreateMap<Category, CategoryModel>();
            //Model to Entity

            CreateMap<ProductModel, Product>();
            CreateMap<CategoryModel, Category>();
        }
    }
}
