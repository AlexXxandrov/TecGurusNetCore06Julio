using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusCommon.Domain;
using TecGurusCommon.Interfaces;

namespace TecGurusCommon.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEFRepository<Category> _categoryRepository;

        public CategoryService(IEFRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }
    }
}
