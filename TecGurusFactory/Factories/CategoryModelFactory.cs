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
    public class CategoryModelFactory : ICategoryModelFactory
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryModelFactory(ICategoryService categoryService1, IMapper mapper)
        {
            _categoryService = categoryService1;
            _mapper = mapper;
        }

        public List<CategoryModel> GetAllCategoriesModel()
        {
            var categories = _categoryService.GetCategories();

            var categoryModel = _mapper.Map<List<CategoryModel>>(categories);
            return categoryModel;
        }
    }
}
