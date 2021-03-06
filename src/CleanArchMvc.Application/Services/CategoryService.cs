using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private  ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntities = await _categoryRepository.GetCategoriesAsync();
            
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntities);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
           var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);
           
           return _mapper.Map<CategoryDTO>(categoryEntity); 
        }

        public async Task Create(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.CreateCategoryAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.UpdateCategoryAsync(categoryEntity);
        }
        public async Task Delete(int? id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);

            await _categoryRepository.RemoveCategoryASync(categoryEntity); 
        }


    }
}
