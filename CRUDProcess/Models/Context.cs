using Microsoft.EntityFrameworkCore;

namespace CRUDProcess.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
    }
}
