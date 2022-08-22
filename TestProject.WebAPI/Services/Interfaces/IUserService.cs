using System.Threading.Tasks;
using TestProject.WebAPI.ViewModels;

namespace TestProject.WebAPI.Services.Interface
{
    public interface IUserService : IService<UserResponse, UserRequest>
    {
        /// <summary>
        /// Get a user by email address.
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <returns>Return a user.</returns>
        Task<UserResponse> GetAsync(string emailAddress);
    }
}