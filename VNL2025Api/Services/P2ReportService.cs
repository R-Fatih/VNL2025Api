using HtmlAgilityPack;

namespace VNL2025Api.Services
{
    public class P2ReportService
    {
        private readonly HttpClient _httpClient;

        public P2ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get the P2 report for the VNL 2025 tournament.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetP2ReportAsync(string id)
        {
           var matchData=await  _httpClient.GetAsync($"https://en.volleyballworld.com/volleyball/competitions/volleyball-nations-league/2025/schedule/{id}/_libraries/_finished-match");
           //var matchData=await  _httpClient.GetAsync($"https://en.volleyballworld.com/volleyball/competitions/volleyball-nations-league/2024/schedule/18954/_libraries/_finished-match");
            var document=new HtmlDocument();
            document.LoadHtml(await matchData.Content.ReadAsStringAsync());
            var reportNode = document.DocumentNode.SelectSingleNode("//a[@class='fa-button -outline -blur vbw-button vbw-button--primary']");
            if (reportNode != null)
            {
                var reportUrl = reportNode.GetAttributeValue("href", null);
                if (!string.IsNullOrEmpty(reportUrl))
                {
                    return  reportUrl ;
                }

            }
            return null; // Return null if no report URL is found

        }
    }
}
