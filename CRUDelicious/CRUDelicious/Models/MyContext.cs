using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
   public class MyContext : DbContext
    {
        // the MyContext class representing a session with our MySQL
        // database allowing us to query for or save data
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<Dish> Dishes { get; set; }
    }
}