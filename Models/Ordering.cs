using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Ordering
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string OrderDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        [Required]
        public string DesiredDeliveryDate { get; set; } = null!;
        [Required]
        public int QuantityDose { get; set; }

        public string? GLN { get; set; } = "null";

        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }
    }
}
