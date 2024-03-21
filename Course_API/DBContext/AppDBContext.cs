using Microsoft.EntityFrameworkCore;
using Course_API.Models;

namespace Course_API.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Book> tblBook { get; set; }
    }
}
