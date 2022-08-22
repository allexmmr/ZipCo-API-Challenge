using TestProject.Data.Entities;

namespace TestProject.WebAPI.ViewModels
{
    /// <summary>
    /// Account Response Class.
    /// </summary>
    public class AccountResponse : BaseResponse
    {
        /// <summary>
        /// Account.
        /// </summary>
        public Account Account { get; set; }
    }
}