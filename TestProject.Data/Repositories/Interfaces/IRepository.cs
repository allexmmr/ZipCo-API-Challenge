using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> CreateAsync(T obj);
    }
}