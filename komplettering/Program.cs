using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;


class DB : DbContext
{
    DbSet<Article> Articles { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Blog> Blogs { get; set; }

    string _path = "blogging.db";


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data source={_path}");
    }


    public static void main(string[] args)
    {
        DB db = new DB();

        db.Users.Add(new User { name= "roble"});
        db.SaveChanges();

        db.Blogs.Add(new Blog { name = "al" });
        db.SaveChanges();


        db.Categories.Add(new Category { name = "BMW" });
        db.SaveChanges();

        db.Articles.Add(new Article { title = "ländsförsäkring" });
        db.SaveChanges();

        Console.WriteLine(db.Articles.First().User.Articles.First().Blog.Articles.First().title);









    }
   
}

public class User
{
    public int? userID { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public List<Article> articles { get; set; }

}
    public class Article
    {
        public string articleID { get; set; }

        public string? title { get; set; }

        public List<Category> categoriesID { get; set; }

        public User user;
        public Blog blog;



    }


    public class Category
    {

        public string categoryID { get; set; }
        public string? name { get; set; }
        public List<Article> articles { get; set; }



    }



    public class Blog
    {
        public int? blogID { get; set; }
        public string? name { get; set; }

        public List<Article>? article { get; } = new();




    } 

