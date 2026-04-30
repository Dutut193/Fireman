using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        public DateTime Date { get; set; }

        // Един пожарникар
        public int? EmployeeId { get; set; }
        public virtual Employees Employee { get; set; }

        // Една пожарна кола
        public int? FireTruckId { get; set; }
        public virtual FireTruck FireTruck { get; set; }
    }
}
