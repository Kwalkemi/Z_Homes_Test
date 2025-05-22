using Microsoft.AspNetCore.Mvc;
using Z_Homes_Test.Models;
using Z_Homes_Test.Service;

namespace Z_Homes_Test.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService { get; set; }
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetData()
        {
            EmployeeBusinessViewModel employeeBusinessViewModel = _employeeService.GetAllEmployee();
            return View(employeeBusinessViewModel);
        }


        [HttpGet]
        public IActionResult InsertData()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult InsertData(EmployeeViewModel employeeViewModel)
        {
            EmployeeViewModel employeeViewModelNew = _employeeService.InsertEmployee(employeeViewModel);
            return View(employeeViewModelNew);
        }
        [HttpGet]
        public IActionResult UpdateData(int Id)
        {
            EmployeeViewModel employeeViewModel = _employeeService.GetEmployeeById(Id);
            return View(employeeViewModel);
        }
        [HttpPost]
        public IActionResult UpdateData(EmployeeViewModel employeeViewModel)
        {
            EmployeeViewModel employeeViewModelNew = _employeeService.UpdateEmployee(employeeViewModel);
            return View(employeeViewModelNew);
        }
        [HttpGet]
        public IActionResult DeleteData(int Id)
        {
            EmployeeViewModel employeeViewModel = _employeeService.GetEmployeeById(Id);
            _employeeService.DeleteEmployee(employeeViewModel);
            return View();
        }
    }
}
