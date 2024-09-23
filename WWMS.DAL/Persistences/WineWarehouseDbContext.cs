using Microsoft.EntityFrameworkCore;

namespace WWMS.DAL.Persistences
{
    public class WineWarehouseDbContext : DbContext
    {
        public WineWarehouseDbContext()
        {

        }

        public WineWarehouseDbContext(DbContextOptions<WineWarehouseDbContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=1;Database=JewelrySalesSystem;Trusted_Connection=true;TrustServerCertificate=true;");

        //        //optionsBuilder.UseSqlServer("Server=tcp:jewelrysalessystem.database.windows.net,1433;Initial Catalog=JewelrySalesSystem;Persist Security Info=False;User ID=jss;Password=@Testpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
