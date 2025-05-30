using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNL2025Api.Enums;
using VNL2025Api.Services;

namespace VNL2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(AllDataService allDataService, P2ReportService p2ReportService) : ControllerBase
    {
        private readonly AllDataService _allDataService = allDataService;
        private readonly P2ReportService _p2ReportService = p2ReportService;

        /// <summary>
        /// Get matches for the VNL 2025 tournament.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMatches(Gender? gender)
        {
            var matches = await _allDataService.GetAllDataAsync(2025);
            var teams = matches.allTeams;
            var filtered = matches?.matches
                .Where(x => gender == null || x.gender == gender?.ToString())

                ;

            var lastData = filtered?.Select(async x =>
            {
                var p2 = x.matchStatus != 0 ? await _p2ReportService.GetP2ReportAsync(x.matchNo.ToString()) : null;
                return new
                {
                    HomeTeam = teams.FirstOrDefault(t => t.no == x.teamANo)?.code,
                    AwayTeam = teams.FirstOrDefault(t => t.no == x.teamBNo)?.code,
                    Date = x.matchDateUtc.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    MatchStatus = x.matchStatus,
                    HomeScore = x.teamAScore,
                    AwayScore = x.teamBScore,
                    Sets = x.sets,
                    Report = "https://en.volleyballworld.com" + x.matchCenterUrl,
                    P2Report = p2 != null ? p2 : null
                };
            });

            return Ok(await Task.WhenAll(lastData));
        }

    }
}
