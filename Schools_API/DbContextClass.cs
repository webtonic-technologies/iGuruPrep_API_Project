using Microsoft.EntityFrameworkCore;
using Schools_API.Models;
using System.Security.Claims;

namespace Schools_API
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {

        }
        public DbSet<Project> tblproject { get; set; }
        public DbSet<Board> tblBoard { get; set; }
        public DbSet<Class> tblClass { get; set; }
        public DbSet<Subject> tblSubject { get; set; }
        public DbSet<Course> tblCourse { get; set; }
    }
}
