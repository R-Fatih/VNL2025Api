namespace VNL2025Api.Entities
{
    public class Match1
    {
        public string competitionSlug { get; set; }
        public bool pinnedCompetition { get; set; }
        public DateTime matchDateUtc { get; set; }
        public string discipline { get; set; }
        public string disciplineText { get; set; }
        public bool isMatchTBD { get; set; }
        public string gender { get; set; }
        public DateTime matchDateTimeLocal { get; set; }
        public int matchNo { get; set; }
        public int matchNoInTournament { get; set; }
        public int matchStatus { get; set; }
        public string ticketLink { get; set; }
        public int tournamentNo { get; set; }
        public int tournamentType { get; set; }
        public int season { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
        public string country { get; set; }
        public string volleyBallTvLink { get; set; }
        public string youTubeLink { get; set; }
        public string matchCenterUrl { get; set; }
        public string worldRankingUrl { get; set; }
        public int currentSetNo { get; set; }
        public Set[] sets { get; set; }
        public object teamAReplacementTBD { get; set; }
        public int teamANo { get; set; }
        public object teamBReplacementTBD { get; set; }
        public int teamBNo { get; set; }
        public object winnerTeamNo { get; set; }
        public int teamAScore { get; set; }
        public int teamBScore { get; set; }
        public string competitionShortName { get; set; }
        public string competitionFullName { get; set; }
        public int roundNo { get; set; }
        public string roundName { get; set; }
        public string roundCode { get; set; }
        public object phase { get; set; }
        public Pool pool { get; set; }
        public string court { get; set; }
        public string genderText { get; set; }
        public string courtText { get; set; }
    }

}
