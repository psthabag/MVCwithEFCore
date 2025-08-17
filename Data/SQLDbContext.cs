using Microsoft.EntityFrameworkCore;
using MVCwithEFCore.Models;

namespace MVCwithEFCore.Data
{
    public class SQLDbContext:DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
