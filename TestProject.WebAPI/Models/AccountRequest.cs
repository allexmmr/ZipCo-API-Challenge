using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestProject.Data.Entities;

namespace TestProject.WebAPI.ViewModels
{
    /// <summary>
    /// Account Request Class.
    /// </summary>
    public class AccountRequest : IValidatableObject
    {
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Account Number.
        /// </summary>
        public string AccountNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (User?.Id <= 0)
            {
                result.Add(new ValidationResult("UserId is not valid.", new string[] { "UserId" }));
            }

            return result;
        }
    }
}