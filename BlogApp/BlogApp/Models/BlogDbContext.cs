using Microsoft.EntityFrameworkCore;

namespace BlogApp.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions db) : base(db)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
