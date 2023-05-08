using Microsoft.EntityFrameworkCore;

namespace Konyvtar.WEBAPI
{
    public class KonyvtarContext: DbContext
    {
        public KonyvtarContext(DbContextOptions options)
            : base(options) 
        {
            
        }


        public virtual DbSet<Book> Books { get; set; }
    }
}
