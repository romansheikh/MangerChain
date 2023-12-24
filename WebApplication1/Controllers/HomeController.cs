using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Repository.Employee;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeRepo employeeRepo;

        public HomeController(IEmployeeRepo employeeRepo)
        {

            this.employeeRepo = employeeRepo;
        }

        public async Task<IActionResult> Index()
        {
            var list = await employeeRepo.GetEmployeeInfo();
            return View(list);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
