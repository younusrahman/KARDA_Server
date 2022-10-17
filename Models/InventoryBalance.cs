using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class InventoryBalance
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string InventoryDateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        [Required]
        public string VaccineSupplierId { get; set; } = null!;
        public virtual VaccineSupplier? VaccineSupplier { get; set; }
        [Required]
        public int QuantityVial { get; set; }
        [Required]
        public int QuantityDose { get; set; }

        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }


    }
}
