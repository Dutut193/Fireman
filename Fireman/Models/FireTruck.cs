using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class FireTruck
    {
        [Key]
        public int VehicleId { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }

        [ForeignKey("FireStation")]
        public int StationId { get; set; }

        public virtual FireDepartment FireStation { get; set; }
    }
}
