using Microsoft.AspNetCore.Mvc;
using SuperMarket.Dtos.Categories;
using SuperMarket.Models;

namespace SuperMarket.Services
{
    public interface ICategoryService
    {
        Task<Category?> CreateAsync([Bind(new[] { "Name" })] CreateCategoryDto createCategoryDto);
        Task<bool> DeleteAsync(int id);
        Task<List<Category>?> GetAllAsync();
        Task<Category?> GetOneAsync(int id);
        Task<bool> UpdateAsync(int id, CreateCategoryDto createCategoryDto);
    }
}