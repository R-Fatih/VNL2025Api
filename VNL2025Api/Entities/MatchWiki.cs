namespace VNL2025Api.Entities
{
    public class MatchWiki
    {
        public string? HomeTeam { get; }
        public string? AwayTeam { get; }
        public DateTime Date { get; }
        public int MatchStatus { get; }
        public int HomeScore { get; }
        public int AwayScore { get; }
        public Set[] Sets { get; }
        public string Report { get; }
        public string? P2Report { get; }
        public string RoundName { get; set; }
        public Pool Pool { get; set; }

        public MatchWiki(string? homeTeam, string? awayTeam, DateTime date, int matchStatus, int homeScore, int awayScore, Set[] sets, string report, string? p2Report, string roundName, Pool pool)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Date = date;
            MatchStatus = matchStatus;
            HomeScore = homeScore;
            AwayScore = awayScore;
            Sets = sets;
            Report = report;
            P2Report = p2Report;
            RoundName = roundName;
            Pool = pool;
        }


    }
}
