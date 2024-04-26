using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Models.Category;
using HandMadeCraftAdminServer.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HandMadeCraftAdminServer.UnitTest
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetAllCategories_Returns_All_Categories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = "1", Name = "Category 1" },
                new Category { Id = "2", Name = "Category 2" }
            };
            var mockDbSet = new Mock<DbSet<Category>>();
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.AsQueryable().GetEnumerator());

            var mockDbContext = new Mock<AppDbContext>();
            mockDbContext.Setup(db => db.Categories).Returns(mockDbSet.Object);

            var categoryService = new CategoryService(mockDbContext.Object);

            // Act
            var result = await categoryService.GetAllCategories();

            // Assert
            Assert.Equal(categories.Count, result.Count());
            foreach (var category in categories)
            {
                Assert.Contains(result, c => c.Id == category.Id && c.Name == category.Name);
            }
        }
    }
}