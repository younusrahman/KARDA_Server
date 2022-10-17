using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Consumption
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        [Required]
        public string UseByDate { get; set; } = null!;

        [Required]
        public int QuantityVial { get; set; }

        [Required]
        public string VaccineSupplierId { get; set; } = null!;
        public virtual VaccineSupplier? VaccineSupplier { get; set; }

        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }
    }
}
