using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.Employee
{
    public class EmployeeRepo: IEmployeeRepo
    {
        private readonly TestDBContext _context;
        public EmployeeRepo(TestDBContext context)
        {
            _context = context;
        }
        #region Employee Info  
        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfo()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _context.Employees.Include(x => x.Position).Include(x=>x.Manager).ToListAsync();
        }
        public async Task<List<EmployeeDetailsViewModel>> GetSalaryWithBonusAndManagerChain(int employeeId)
        {
            var employeeChain = await GetManagerChain(employeeId);
            var employeeDetailsList = new List<EmployeeDetailsViewModel>();
            foreach (var employee in employeeChain)
            {
                var salaryWithBonus = CalculateSalaryWithBonus(employee);
                var employeeDetails = new EmployeeDetailsViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    IsBonusAdded = employee.IsBonusAdded,  
                    Position = employee.Position.Name,
                    PositionId = employee.Position.Id,
                    SalaryWithBonus = salaryWithBonus,
                    JoinDate = employee.JoinDate
                };
                employeeDetailsList.Add(employeeDetails);
            }
            return employeeDetailsList;
        }     
        private decimal CalculateSalaryWithBonus(EmployeeInfo employee)
        {
            decimal baseSalary = employee.Salary;
            decimal bonusAmount = 0;           
            if ((DateTime.Now - employee.JoinDate).TotalDays >= 4 * 365)
            {   bool isLeapYear = DateTime.IsLeapYear(DateTime.Now.Year);                              
                bonusAmount = isLeapYear ? 10000 : 8000;
                if (employee.Manager != null && employee.JoinDate <= employee.Manager.JoinDate)
                {
                    bonusAmount += 2000; 
                }
                else
                {
                    bonusAmount += 1000; 
                }
            }
            else
            {                
                bonusAmount = (DateTime.Now.Year % 4 == 0) ? 5000 : 3000;               
                if (employee.Manager != null && employee.JoinDate <= employee.Manager.JoinDate)
                {
                    bonusAmount += 1000;           
                }
                else
                {
                    bonusAmount += 500;
                }
            }
            return baseSalary + bonusAmount;
        }
        private async Task<List<EmployeeInfo>> GetManagerChain(int employeeId)
        {
            var managerChain = new List<EmployeeInfo>();
            var employee = await _context.Employees
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            while (employee != null)
            {
                managerChain.Add(employee);
                employee = await _context.Employees
                    .Include(e => e.Position)
                    .FirstOrDefaultAsync(e => e.Id == employee.ManagerId);
            }
            return managerChain;
        }                
        #endregion
    }
}
