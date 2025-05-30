using VNL2025Api.Entities;

namespace VNL2025Api.Services
{
    public class AllDataService
    {
        private readonly HttpClient _httpClient;
        public AllDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Get all data for the VNL 2025 tournament.
        /// </summary>
        /// <returns></returns>
        public async Task<Rootobject> GetAllDataAsync(int? year)
        {
            string url = year switch
            {
                2024 => "https://en.volleyballworld.com/api/v1/volley-tournament/2024-05-1/2024-08-1/1439;1440",
               2025 => "https://en.volleyballworld.com/api/v1/volley-tournament/2025-05-26/2025-07-16/1542;1543",
                _ => throw new ArgumentException("Invalid year specified.")
            };
            var response = await _httpClient.GetFromJsonAsync<Rootobject>(url);
            return response;
        }
    }
}
