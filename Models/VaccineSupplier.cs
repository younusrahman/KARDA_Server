using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class VaccineSupplier
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string SupplierName { get; set; } = null!;

        [Required]
        public string HealthcareProvidersId { get; set; } = null!;
        public virtual HealthcareProvider? HealthcareProviders { get; set; }


    }
}
