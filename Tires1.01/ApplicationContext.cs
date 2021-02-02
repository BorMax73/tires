using System.Data.Entity;

namespace Tires1._01
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }
        public DbSet<Tire> Tires { get; set; }
        
    }
}