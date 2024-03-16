using ControlPanel_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlPanel_API.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Role> tblRole { get; set; }
        public DbSet<Designation> tblDesignation { get; set; }
        public DbSet<Magazine> tblMagazine { get; set; }
        //tblEmoyee missing from DB
        // public DbSet<Employee> tblEmployee { get; set; }
    }
}
