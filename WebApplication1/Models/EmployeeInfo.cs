using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public bool IsBonusAdded { get; set; }
        public DateTime JoinDate { get; set; }   
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int? ManagerId { get; set; }
        public EmployeeInfo Manager { get; set; }
    }  
}
