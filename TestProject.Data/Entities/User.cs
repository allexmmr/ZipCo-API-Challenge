using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Name field cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Email Address field cannot be longer than 50 characters.")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public decimal MonthlySalary { get; set; }

        public decimal MonthlyExpenses { get; set; }
    }
}