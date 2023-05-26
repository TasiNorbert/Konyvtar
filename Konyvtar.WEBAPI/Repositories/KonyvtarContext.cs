using Konyvtar.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.ContentModel;

namespace Konyvtar.WEBAPI.Repositories
{
    public class KonyvtarContext : DbContext
    {
        public KonyvtarContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }



        public virtual DbSet<Book>? Books { get; set; }

        public virtual DbSet<Borrowed>? Borroweds { get; set; }

         public virtual DbSet<Member>? Members { get; set; }
    }
}
