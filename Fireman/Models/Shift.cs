namespace FIREMAN.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FireTruckId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
