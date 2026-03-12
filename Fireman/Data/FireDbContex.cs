using FIREMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace FIREMAN.Data
{
    public class FireDbContex : DbContext
    {
        public DbSet<FireDepartment> FireStations { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<FireTruck> FireVehicles { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentLocation> IncidentAddresses { get; set; }
        public DbSet<TeamParticipationInIncident> IncidentTeams { get; set; }
    }
}
