using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Areas.Admin.ViewModels
{
    public class ArticleAddVM
    {
        public string Title { get; set; }
        public string SlugUri { get; set; }
        public string Body { get; set; }
        public string PictureURL { get; set; }
        public IFormFile Picture { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public int Views { get; set; }
        public bool Status { get; set; }
        //public string StatusText { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
