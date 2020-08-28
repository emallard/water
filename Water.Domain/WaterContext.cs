using Microsoft.EntityFrameworkCore;

namespace Water.Domain
{
    public class WaterContext : DbContext
    {

        public WaterContext(DbContextOptions<WaterContext> options) : base(options)
        {

        }
        public DbSet<Area> Areas { get; set; }
    }
}
