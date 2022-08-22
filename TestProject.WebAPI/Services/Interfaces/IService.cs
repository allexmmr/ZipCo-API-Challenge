using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Services.Interface
{
    public interface IService<TResponse, TRequest>
    {
        /// <summary>
        /// List all T objects.
        /// </summary>
        /// <returns>Return a list of T objects.</returns>
        Task<IEnumerable<TResponse>> ListAsync();

        /// <summary>
        /// Create a T object.
        /// </summary>
        /// <param name="request">TRequest request</param>
        /// <returns>Return the created object.</returns>
        Task<TResponse> CreateAsync(TRequest request);
    }
}