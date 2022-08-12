using System.Data.Entity;

namespace BlogApp.Models
{
    public class DbInitialization
    {
        public BlogDbContext context;

        public static void Initialization (BlogDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Categories.Any())
            {
                var categories = new Category[]
            {
                new Category { Id =1, CategoryName = "Teknoloji", SlugUri ="teknoloji" },
                new Category { Id =2, CategoryName = "C#", SlugUri ="c-sharp" },
                new Category { Id =3, CategoryName = ".NET Framework 6", SlugUri =".net-framework-6" },
                new Category { Id =4, CategoryName = "Microsoft", SlugUri ="microsoft" },
                new Category { Id =5, CategoryName = "Windows", SlugUri ="windows" },
                new Category { Id =6, CategoryName = "HTML-CSS", SlugUri ="html-css" },
            };
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }
            }
            
            if (context.Articles.Any())
            {
                var articles = new Article[]
            {
                new Article{ Id =1, Title="C# Yenilikler", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="Ali Yılmaz", CategoryID=2,
                    SlugUri="c-sharp-yenilikler", PictureURL="site/images/nick-karvounis-78711.jpg", Views=1},
                 new Article{ Id =2, Title="Windows Yenilikler", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="Rıza Küçük", CategoryID=4,
                    SlugUri="windows-yenilikler", PictureURL="site/images/science-578x362.jpg", Views=50},
                 new Article{ Id =3, Title="Windows Yenilikler", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="Mine Bulut", CategoryID=4,
                    SlugUri="windows-yenilikler", PictureURL="site/images/nick-karvounis-78711.jpg", Views=1},
                 new Article{ Id =4, Title="Windows 11", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="Yaşar Yıldız", CategoryID=4,
                    SlugUri="windows-yenilikler", PictureURL="site/images/joe-gardner-75333.jpg", Views=1},
                 new Article{ Id =5, Title="Robot Teknolojisi", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="İpek Umut", CategoryID=1,
                    SlugUri="windows-yenilikler", PictureURL="site/images/ryan-moreno-98837.jpg", Views=1},
                 new Article{ Id =2, Title="Yapay Zeka", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla malesuada enim id enim congueconvallis. Praesent a cursus orci. Proin mauris eros, rhoncus in risus nec, " +
                "vestibulum dignissimdiam. Duis dapibus, magna ac fringilla consectetur, tellus quam aliquam quam, molestie " +
                "tinciduntjusto risus et nunc. Donec quis justo nec diam hendrerit facilisis placerat non magna. Class aptenttaciti " +
                "sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", AuthorName="Yalçın Kılıç", CategoryID=1,
                    SlugUri="windows-yenilikler", PictureURL="site/images/10-1-1-875x500.jpg", Views=10},

            };
                foreach (var article in articles)
                {
                    context.Articles.Add(article);
                }
            }
            
            if (context.Tags.Any())
            {
                var tags = new Tag[]
           {
                new Tag{ Id =1, Title="C#", SlugUri="c-sharp"},
                new Tag{ Id =2, Title="Windows", SlugUri="windows"},
                new Tag {Id =3, Title="Microsoft", SlugUri="microsoft"},
                new Tag{ Id =4, Title=".NET", SlugUri=".net"}
           };
                foreach (var tag in tags)
                {
                    context.Tags.Add(tag);
                }
            }
           
            context.SaveChanges();
        }
    }
}
