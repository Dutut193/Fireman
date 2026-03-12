using System.ComponentModel.DataAnnotations;

namespace FIREMAN.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public virtual IncidentLocation Address { get; set; }

        public virtual ICollection<TeamParticipationInIncident> IncidentTeams { get; set; }
    }
}
