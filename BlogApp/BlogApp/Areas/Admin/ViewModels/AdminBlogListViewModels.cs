namespace BlogApp.Areas.Admin.ViewModels
{
    public class AdminBlogListViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PictureURL { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public string SlugUri { get; set; }
        public int Views { get; set; }
        //public string Status { get; set; }
        public string CategoryName { get; set; }

    }
}
