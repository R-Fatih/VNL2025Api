using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VNL2025Api.Entities;
using VNL2025Api.Enums;
using VNL2025Api.Services;

namespace VNL2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AllDataService _allDataService;

        public TeamsController(AllDataService allDataService)
        {
            _allDataService = allDataService;
        }

        /// <summary>
        ///Get teams participating in the VNL 2025 tournament. 
        /// </summary>
        /// <param name="tournament">Filter by men or women tournament</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTeams(Tournament? tournament)
        {
            var teams = await _allDataService.GetAllDataAsync(2025);
            return Ok(teams?.allTeams.Where(x => tournament == null || x.tournamentCode == tournament?.ToString()));
        }


    }
}
