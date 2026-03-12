using System.ComponentModel.DataAnnotations;

namespace FIREMAN.Models
{
    public class FireDepartment
    {
        [Key]
        public int StationId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }
    }
}
