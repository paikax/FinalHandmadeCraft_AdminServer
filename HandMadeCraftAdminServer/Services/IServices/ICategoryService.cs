using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Models.Category;


namespace HandMadeCraftAdminServer.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(string id);
        
    }
}