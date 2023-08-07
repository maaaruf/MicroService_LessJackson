using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private IConfiguration Config { get; }


        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            Config = config;
            _httpClient = httpClient;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(Config["CommandsService"], httpContent);

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