using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class DeliveryStatus
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string DeliveryDate { get; set; } = null!;

        [Required]
        public string PlannedDeliveryDate { get; set; } = null!;

        [Required]
        public int QuantityVial { get; set; }

        public string? GLN { get; set; }

        [Required]
        public string VaccineSupplierId { get; set; } = null!;
        public virtual VaccineSupplier? VaccineSupplier { get; set; }


        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }




    }
}
