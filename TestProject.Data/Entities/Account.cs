using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Data.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key for User
        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        [StringLength(12, ErrorMessage = "The Account Number field cannot be longer than 12 characters.")]
        public string AccountNumber { get; set; }
    }
}