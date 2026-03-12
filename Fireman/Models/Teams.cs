using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }

        [ForeignKey("FireStation")]
        public int StationId { get; set; }

        public virtual FireDepartment FireStation { get; set; }

        public virtual ICollection<TeamParticipationInIncident> IncidentTeams { get; set; }
    }
}

