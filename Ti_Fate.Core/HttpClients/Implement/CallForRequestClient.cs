using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Ti_Fate.Core.HttpClients.Interface;

namespace Ti_Fate.Core.HttpClients.Implement
{
    public class CallForRequestClient : ICallForRequestClient
    {
        private readonly HttpClient _client;
        public CallForRequestClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            var basicUrl = configuration.GetValue<string>("BasicUrl");
            _client.BaseAddress = new Uri(basicUrl);
        }
        public async Task<string> SendRequestTask()
        {
            var response = await _client.GetStringAsync("/ForRequest/Index");
            return response;
        }
    }
}
