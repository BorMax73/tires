using System.Data.Entity;

namespace Tires1._01
{
    public class FavoriteContext : DbContext
    {
        public FavoriteContext() : base("DefaultConnection")
        {

        }
        
        public DbSet<Tire> favoriteTires { get; set; }
    }
}