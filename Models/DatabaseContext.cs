using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt): base(opt)
        {

        }

        public virtual DbSet<Capacity> Capacitys { get; set; }
        public virtual DbSet<Consumption> Consumptions { get; set; }

        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<HealthcareProvider> HealthcareProviders { get; set; }

        public virtual DbSet<InventoryBalance> InventoryBalances { get; set; }

        public virtual DbSet<Ordering> Orderings { get; set; }

        public virtual DbSet<VaccineSupplier> VaccineSuppliers { get; set; }
    }
}
