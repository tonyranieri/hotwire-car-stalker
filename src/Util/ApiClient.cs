using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotwireCarStalker.Util
{
    public class ApiClient
    {
        public static async Task<string> GetAsync(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync(url);
            return await stringTask;
        }
    }
}