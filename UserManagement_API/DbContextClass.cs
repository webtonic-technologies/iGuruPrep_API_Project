using Microsoft.EntityFrameworkCore;
using UserManagement_API.Models;


namespace iGuruPrep
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        public DbSet<UserRegistration> tblUser { get; set; }
    }
}