using Microsoft.EntityFrameworkCore;

namespace Course_API.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

    }
}
