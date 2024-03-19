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
        //tblEmoyee missing from DB
        // public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Ticket> tblTicket { get; set; }
        public DbSet<Feedback> tblUserFeedback { get; set; }
        public DbSet<Syllabus> tblSyllabus { get; set; }
        public DbSet<Board> tblBoard { get; set; }
        public DbSet<Class> tblClass { get; set; }
        public DbSet<Course> tblCourse { get; set; }
    }
}
