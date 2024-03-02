using System.ComponentModel.DataAnnotations;

namespace HandMadeCraftAdminServer.Models.Category
{
    public class Category : BaseEntity.BaseEntity 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}