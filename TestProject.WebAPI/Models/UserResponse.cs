using TestProject.Data.Entities;

namespace TestProject.WebAPI.ViewModels
{
    /// <summary>
    /// User Response Class.
    /// </summary>
    public class UserResponse : BaseResponse
    {
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; set; }
    }
}