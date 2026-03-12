using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIREMAN.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public string Phone { get; set; }

        [ForeignKey("FireStation")]
        public int StationId { get; set; }

        public virtual FireDepartment FireStation { get; set; }


    }
}
