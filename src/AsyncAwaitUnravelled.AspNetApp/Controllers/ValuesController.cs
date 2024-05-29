using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncAwaitUnravelled.AspNetApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            var result = GetStringAsync(0).Result;
            return result;
        }

        // GET api/values/1
        public async Task<string> Get(int id)
        {
            var result = await GetStringAsync(id);
            return result;
        }

        private async Task<string> GetStringAsync(int i)
        {
            await Task.Delay(1000);
            return $"value {i}";
        }
    }
}
