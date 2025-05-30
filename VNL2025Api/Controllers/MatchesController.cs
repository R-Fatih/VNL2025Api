using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using VNL2025Api.Entities;
using VNL2025Api.Enums;
using VNL2025Api.Services;

namespace VNL2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(
        AllDataService allDataService
        , P2ReportService p2ReportService,
        WikiFormatterService wikiFormatterService) : ControllerBase
    {
        private readonly AllDataService _allDataService = allDataService;
        private readonly P2ReportService _p2ReportService = p2ReportService;
        private readonly WikiFormatterService _wikiFormatterService = wikiFormatterService;

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
                return new MatchWiki(
teams.FirstOrDefault(t => t.no == x.teamANo)?.code,
teams.FirstOrDefault(t => t.no == x.teamBNo)?.code,
x.matchDateUtc.AddHours(3),
x.matchStatus,
x.teamAScore,
x.teamBScore,
x.sets,
"https://en.volleyballworld.com" + x.matchCenterUrl,
p2 != null ? p2 : null,
x.roundName[0].ToString() + x.roundName.Split(' ')[1],
x.pool
                );
            });
            var formatteds = await Task.WhenAll(lastData);
            var matches2 = _wikiFormatterService.FormatMatch(formatteds.ToList());

            foreach (var group in formatteds.GroupBy(x => x.RoundName))
            {
                Console.WriteLine($"=== {group.Key}. hafta ===");              

                foreach (var pool in group.GroupBy(y=>y.Pool.name))
                {
                    Console.WriteLine($"=== {pool.Key} ===");
                    foreach (var match in pool)
                    {
                        Console.WriteLine($"{{{{2025 FIVB Erkekler Voleybol Milletler Ligi maçları|{match.RoundName}-{match.HomeTeam}-{match.AwayTeam}}}}}");

                    }
                }
            }
            return Ok(string.Join('\n',matches2));
        }

       


    }
}
