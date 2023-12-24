using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository.Employee;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo repo;

        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            EmployeeDetailsViewModel obj = new EmployeeDetailsViewModel();
            return View(obj);
        }

        [HttpGet]
        [Route("api/Employee/GetManagerChain/{empCode}")]
        public async Task<IActionResult> GetManagerChain(int empCode)
        {
            var managerChain = await repo.GetSalaryWithBonusAndManagerChain(empCode);
            if (managerChain != null)
            {
                return Json(managerChain);
            }
            return Json($"Employee with ID {empCode} not found");

        }
    }
}
