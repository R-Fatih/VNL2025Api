namespace VNL2025Api.Entities
{

    public class Rootobject
    {
        public Match1[] matches { get; set; }
        public object[] todayMatches { get; set; }
        public Allteam[] allTeams { get; set; }
        public Alltournament[] allTournaments { get; set; }
        public Worldranking worldRanking { get; set; }
    }

}
