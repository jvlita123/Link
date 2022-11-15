using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService accountService)
        {
            _employeeService = accountService;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _employeeService.GetAll();

            return View();
        }
    }
}