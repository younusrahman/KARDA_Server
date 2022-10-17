namespace Server.Models
{
    public class HealthcareProvider
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;

        public string JoinDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public virtual ICollection<Capacity>? Capacity { get; set; }
        public virtual ICollection<Consumption>? Consumption { get; set; }
        public virtual ICollection<DeliveryStatus>? DeliveryStatus { get; set; }
        public virtual ICollection<InventoryBalance>? InventoryBalance { get; set; }
        public virtual ICollection<Ordering>? Ordering { get; set; }
        public virtual ICollection<VaccineSupplier>? VaccineSupplier { get; set; }


    }
}
