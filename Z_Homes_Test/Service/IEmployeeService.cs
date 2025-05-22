using Z_Homes_Test.Models;

namespace Z_Homes_Test.Service
{
    public interface IEmployeeService
    {
        public EmployeeBusinessViewModel GetAllEmployee();
        public EmployeeViewModel GetEmployeeById(int Id);
        public EmployeeViewModel UpdateEmployee(EmployeeViewModel employeeViewModel);
        public EmployeeViewModel InsertEmployee(EmployeeViewModel employeeViewModel);
        public void DeleteEmployee(EmployeeViewModel employeeViewModel);

    }
}
