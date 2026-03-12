using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class TeamParticipationInIncident
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [ForeignKey("Incident")]
        public int IncidentId { get; set; }

        public virtual Teams Team { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
