using Microsoft.EntityFrameworkCore;
using Z_Homes_Test.Business;
using Z_Homes_Test.Entities;
using Z_Homes_Test.Models;


namespace Z_Homes_Test.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeDbContext dbContext;
        
        public EmployeeService() {
            dbContext = new EmployeeDbContext();
        }

        public EmployeeBusinessViewModel GetAllEmployee()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            
            EmployeeBusinessViewModel employeeBusinessViewModel = new EmployeeBusinessViewModel();
            employeeBusinessViewModel.employeeViewModels = new List<EmployeeViewModel>();
            if (employees.Count > 0)
            {
                foreach (Employee employee in employees)
                {
                    EmployeeViewModel employeeViewModel = BindTableToViewModel(employee);
                    employeeBusinessViewModel.employeeViewModels.Add(employeeViewModel);
                }
            }
            else
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeBusinessViewModel.employeeViewModels.Add(employeeViewModel);
            }
            return employeeBusinessViewModel;
        }

        public EmployeeViewModel GetEmployeeById(int Id)
        {
            Employee employees = dbContext.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();

            
                EmployeeViewModel employeeViewModel = BindTableToViewModel(employees);
                
            
            return employeeViewModel;
        }

        public EmployeeViewModel UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = BindViewModelToTable(employeeViewModel);


            dbContext.Employees.Add(employee);
            dbContext.Entry(employee).State = EntityState.Modified;
            dbContext.SaveChanges();

            Employee employees = dbContext.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();


            EmployeeViewModel employeeViewModelnew = BindTableToViewModel(employees);


            return employeeViewModelnew;

        }

        public EmployeeViewModel InsertEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = BindViewModelToTable(employeeViewModel);


            dbContext.Employees.Add(employee);
            
            dbContext.SaveChanges();
            Employee employees = dbContext.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();


            EmployeeViewModel employeeViewModelnew = BindTableToViewModel(employees);


            return employeeViewModelnew;
        }

        public void DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = dbContext.Employees.Where(x => x.EmployeeId == employeeViewModel.EmployeeId).FirstOrDefault();


            dbContext.Employees.Remove(employee);

            dbContext.SaveChanges();
        }





        private EmployeeViewModel BindTableToViewModel(Employee employee)
        {
            SalaryFactoryComponent salaryFactoryComponent = new SalaryFactoryComponent();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeId = employee.EmployeeId;
            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.DepartmentName = employee.DepartmentName;
            employeeViewModel.BasicSalary = employee.BasicSalary;
            employeeViewModel.HRAComponent = salaryFactoryComponent.GetSalaryComponent("HRA").GetAmount(employeeViewModel.BasicSalary);
            employeeViewModel.TAComponent = salaryFactoryComponent.GetSalaryComponent("TA").GetAmount();
            employeeViewModel.DAComponent = salaryFactoryComponent.GetSalaryComponent("DA").GetAmount(employeeViewModel.BasicSalary);
            return employeeViewModel;
        }


        private Employee BindViewModelToTable(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
            employee.EmployeeId = employeeViewModel.EmployeeId;
            employee.FirstName = employeeViewModel.FirstName;
            employee.LastName = employeeViewModel.LastName;
            employee.DepartmentName = employeeViewModel.DepartmentName;
            employee.BasicSalary = employeeViewModel.BasicSalary;
            return employee;
        }
    }
}
