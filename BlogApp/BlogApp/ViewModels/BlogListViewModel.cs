namespace BlogApp.ViewModels
{
    public class BlogListViewModel
    {
        public string Title { get; set; }
        public string PictureURL { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public string SlugUri { get; set; }
        public string BlogBody { get; set; }
        public bool Status { get; set; }
    }
}
