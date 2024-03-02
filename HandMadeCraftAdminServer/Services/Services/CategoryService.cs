using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace HandMadeCraftAdminServer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(string id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
        }
    }
}