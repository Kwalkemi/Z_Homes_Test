using Microsoft.EntityFrameworkCore;

namespace Z_Homes_Test.Entities
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext() : base()
        {
        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) 
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-IE4OVRQ\SQLEXPRESS;Initial Catalog=HomesTestDB;Integrated Security=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-IE4OVRQ\SQLEXPRESS;Database=HomesTestDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        
        public DbSet<Employee> Employees { get; set; }

    }
}
