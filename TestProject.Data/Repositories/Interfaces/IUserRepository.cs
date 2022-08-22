using System.Threading.Tasks;
using TestProject.Data.Entities;

namespace TestProject.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string emailAddress);
    }
}