using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Kategori adı zorunlu alan.")]
        [StringLength(100)]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(100)]
        public string SlugUri { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
