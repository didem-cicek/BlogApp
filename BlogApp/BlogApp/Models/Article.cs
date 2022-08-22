using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Article : BaseEntity
    { 
        [Required]
        [StringLength(160)]
        public string Title { get; set; }
        [Required]
        [StringLength(160)]
        public string SlugUri { get; set; }
        [Required]
        public string Body { get; set; }
        [StringLength(128)]
        public string PictureURL { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        
        [StringLength(64)]
        [Required]
        public string AuthorName { get; set; }
        public int Views { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool Status { get; set; }


    }
}
