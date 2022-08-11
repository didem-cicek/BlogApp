using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string SlugUri  { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
