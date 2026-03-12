using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class IncidentLocation
    {
        [Key]
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        [ForeignKey("Incident")]
        public int IncidentId { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
