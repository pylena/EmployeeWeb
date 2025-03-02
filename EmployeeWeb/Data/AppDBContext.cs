using EmployeeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWeb.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }



    }
}
