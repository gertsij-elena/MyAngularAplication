using Microsoft.EntityFrameworkCore;

namespace MyAngularAplication.Model
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
