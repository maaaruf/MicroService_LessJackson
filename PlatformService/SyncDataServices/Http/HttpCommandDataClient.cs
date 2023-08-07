using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _config { get; }


        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(_config["CommandsService"], httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to Commands Service was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to Commands Service was NOT OK!");
            }
        }
    }
}