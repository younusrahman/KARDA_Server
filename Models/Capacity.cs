using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Capacity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string CapacityDate { get; set; } = null!;
        [Required]
        public string CapacityDoses { get; set; } = null!;


        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }


    }
}
