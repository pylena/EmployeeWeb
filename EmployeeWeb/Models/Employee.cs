using System.ComponentModel.DataAnnotations;

namespace EmployeeWeb.Models

{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public string Position { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]

        public decimal Salary { get; set; }
    }
}
