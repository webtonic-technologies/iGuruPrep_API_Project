using Config_API.Models;
using iGuruPrep.Models;
using Microsoft.EntityFrameworkCore;


namespace iGuruPrep
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Board> tblBoard { get; set; }
        public DbSet<Class> tblClass { get; set; }
        public DbSet<Subject> tblSubject { get; set; }
        public DbSet<Course> tblCourse { get; set; }
        public DbSet<StatusMessages> tblStatusMessage { get; set; }
        public DbSet<ClassCourseMapping> tblClassCourses { get; set; }
        public DbSet<QuestionLevel> tblDifficultyLevel { get; set; }  
    }
}