using Microsoft.EntityFrameworkCore;

namespace AMS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>contest):base(contest)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
