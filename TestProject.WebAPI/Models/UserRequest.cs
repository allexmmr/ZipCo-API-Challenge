using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.ViewModels
{
    /// <summary>
    /// User Request Class.
    /// </summary>
    public class UserRequest : IValidatableObject
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email Address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Monthly Salary.
        /// </summary>
        public decimal MonthlySalary { get; set; }

        /// <summary>
        /// Monthly Expenses.
        /// </summary>
        public decimal MonthlyExpenses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (MonthlySalary <= 0)
            {
                result.Add(new ValidationResult("Monthly salary is not valid.", new string[] { "MonthlySalary" }));
            }

            if (MonthlyExpenses <= 0)
            {
                result.Add(new ValidationResult("Monthly expenses is not valid.", new string[] { "MonthlyExpenses" }));
            }

            return result;
        }
    }
}