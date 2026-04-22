using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperMarket.Data;
using SuperMarket.Dtos.Categories;
using SuperMarket.Models;

namespace SuperMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>?> GetAllAsync()
        {
            var categories = await _context.Categories.AsNoTracking()
                .Include(c => c.Posts)
                .ToListAsync();
            return categories;
        }

        public async Task<Category?> GetOneAsync(int id)
        {
            var category = await _context.Categories.AsNoTracking()
                .Include(c => c.Posts)
                .Where(c => c.CategoryId == id)
                .Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name, Posts = c.Posts })
                .FirstOrDefaultAsync();
            return category;
        }

        public async Task<Category?> CreateAsync([Bind("Name")] CreateCategoryDto createCategoryDto)
        {
            Category newCategory = new Category { Name = createCategoryDto.Name };
            await _context.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<bool> UpdateAsync(int id, CreateCategoryDto createCategoryDto)
        {
            var existCategory = await _context.Categories.FindAsync(id);
            if (existCategory is null)
            {
                return false;
            }
            _context.Categories.Update(new Category { CategoryId = existCategory.CategoryId, Name = createCategoryDto.Name, Posts = existCategory.Posts });
            _context.Entry(existCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.CategoryId == id);

            _context.Remove(category!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
