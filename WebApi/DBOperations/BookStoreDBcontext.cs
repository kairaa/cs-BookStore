using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public class BookStoreDBContext : DbContext, IBookStoreDBContext
  {
    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {
    }

    public DbSet<Book> Books{ get; set; }  //Book database tarafında Books tablosuna karşılık gelir 
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get;  set; }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }
  }
}