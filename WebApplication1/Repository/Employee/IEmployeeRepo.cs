using WebApplication1.Models;

namespace WebApplication1.Repository.Employee
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfo();
        Task<List<EmployeeDetailsViewModel>> GetSalaryWithBonusAndManagerChain(int employeeId);
    }
}
