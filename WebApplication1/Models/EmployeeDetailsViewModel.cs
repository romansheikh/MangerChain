using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeDetailsViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int? PositionId { get; set; }
        public decimal? Salary { get; set; }

        [Display(Name="Salary with Bonus")]
        public decimal? SalaryWithBonus { get; set; }
        public bool? IsBonusAdded { get; set; }

        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JoinDate { get; set; }

    }
}
