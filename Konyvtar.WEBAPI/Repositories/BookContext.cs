using Microsoft.EntityFrameworkCore;
using Konyvtar.Contracts;

namespace Konyvtar.WEBAPI.Repositories
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }
    }
}
