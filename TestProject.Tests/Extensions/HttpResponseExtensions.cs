using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestProject.Tests.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task<T> ReadBody<T>(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
