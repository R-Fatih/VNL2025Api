using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNL2025Api.Entities;
using VNL2025Api.Enums;
using VNL2025Api.Services;

namespace VNL2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingsController : ControllerBase
    {
        private readonly AllDataService _allDataService;
        public StandingsController(AllDataService allDataService)
        {
            _allDataService = allDataService;
        }
        /// <summary>
        /// Get standings for the VNL 2025 tournament.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStandings(Gender? gender)
        {
            var data = await _allDataService.GetAllDataAsync(2024);
            var teams = data.allTeams;
            var matchesInGroupStage = data.matches
                .Where(x => x.roundName.Contains("Week"))
                .Where(x=>x.gender==null||x.gender==gender?.ToString());
            var homeMatches = matchesInGroupStage
                .GroupBy(x => new { x.teamANo })
                .Select(g => new Standing
                {
                    TeamNo = g.Key.teamANo,
                    Wins = g.Count(m => m.teamAScore > m.teamBScore),
                    Losses = g.Count(m => m.teamAScore < m.teamBScore),
                    Win3_0 = g.Count(m => m.teamAScore == 3 && m.teamBScore == 0),
                    Win3_1 = g.Count(m => m.teamAScore == 3 && m.teamBScore == 1),
                    Win3_2 = g.Count(m => m.teamAScore == 3 && m.teamBScore == 2),
                    Loss0_3 = g.Count(m => m.teamAScore == 0 && m.teamBScore == 3),
                    Loss1_3 = g.Count(m => m.teamAScore == 1 && m.teamBScore == 3),
                    Loss2_3 = g.Count(m => m.teamAScore == 2 && m.teamBScore == 3),
                    PointsWin = g.Sum(m => m.sets.Sum(x=>x.pointsTeamA)),
                    PointsLoss = g.Sum(m => m.sets.Sum(x => x.pointsTeamB)),
                    SetsWin = g.Sum(m => m.teamAScore),
                    SetsLoss = g.Sum(m => m.teamBScore),

                });
            var awayMatches = matchesInGroupStage
                .GroupBy(x => new { x.teamBNo })
                .Select(g => new Standing
                {
                    TeamNo = g.Key.teamBNo,
                    Wins = g.Count(m => m.teamBScore > m.teamAScore),
                    Losses = g.Count(m => m.teamBScore < m.teamAScore),
                    Win3_0 = g.Count(m => m.teamBScore == 3 && m.teamAScore == 0),
                    Win3_1 = g.Count(m => m.teamBScore == 3 && m.teamAScore == 1),
                    Win3_2 = g.Count(m => m.teamBScore == 3 && m.teamAScore == 2),
                    Loss0_3 = g.Count(m => m.teamBScore == 0 && m.teamAScore == 3),
                    Loss1_3 = g.Count(m => m.teamBScore == 1 && m.teamAScore == 3),
                    Loss2_3 = g.Count(m => m.teamBScore == 2 && m.teamAScore == 3),
                    PointsWin = g.Sum(m => m.sets.Sum(x => x.pointsTeamB)),
                    PointsLoss = g.Sum(m => m.sets.Sum(x => x.pointsTeamA)),
                    SetsWin = g.Sum(m => m.teamBScore),
                    SetsLoss = g.Sum(m => m.teamAScore),
                });
            var aggregatedData=homeMatches.Union(awayMatches)
                .GroupBy(x => x.TeamNo)
                .Select(g => new Standing
                {
                    TeamNo = g.Key,
                    TeamName=teams.FirstOrDefault(t => t.no == g.Key)?.code ?? "Unknown",
                    Wins = g.Sum(m => m.Wins),
                    Losses = g.Sum(m => m.Losses),
                    Win3_0 = g.Sum(m => m.Win3_0),
                    Win3_1 = g.Sum(m => m.Win3_1),
                    Win3_2 = g.Sum(m => m.Win3_2),
                    Loss0_3 = g.Sum(m => m.Loss0_3),
                    Loss1_3 = g.Sum(m => m.Loss1_3),
                    Loss2_3 = g.Sum(m => m.Loss2_3),
                    PointsWin = g.Sum(m => m.PointsWin),
                    PointsLoss = g.Sum(m => m.PointsLoss),
                    SetsWin = g.Sum(m => m.SetsWin),
                    SetsLoss = g.Sum(m => m.SetsLoss),
                });

            return Ok(aggregatedData
                .OrderByDescending(x=>x.Wins)
                .ThenByDescending(x=>x.Points)
                .ThenByDescending(x=>x.SetsRatio)
                .ThenByDescending(x=>x.PointsRatio));
        }
    }
}
