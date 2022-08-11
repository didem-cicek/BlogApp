using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(100)]
        public string SlugUri { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
