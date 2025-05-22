namespace Z_Homes_Test.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public int BasicSalary { get; set; }
        public decimal HRAComponent { get; set; }
        public decimal TAComponent { get; set; }
        public decimal DAComponent { get; set; }
    }
}
