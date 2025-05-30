namespace VNL2025Api.Entities
{
    public class Match
    {
        public int t_CallTimeStamp { get; set; }
        public DateTime d_CalcTimeUtc { get; set; }
        public bool b_FirstMatchFlag { get; set; }
        public string n_Tournament_No { get; set; }
        public string n_No { get; set; }
        public string c_teamACode { get; set; }
        public string f_PreHomeWRS { get; set; }
        public string n_PreHomeWR { get; set; }
        public string c_teamBCode { get; set; }
        public string f_PreAwayWRS { get; set; }
        public string n_PreAwayWR { get; set; }
        public DateTime d_DateTimeUTC { get; set; }
        public string b_Men { get; set; }
        public string c_Organizer { get; set; }
        public string c_Tournament { get; set; }
        public string incr_30 { get; set; }
        public string incr_31 { get; set; }
        public string incr_32 { get; set; }
        public string incr_23 { get; set; }
        public string incr_13 { get; set; }
        public string incr_03 { get; set; }
        public string WR_Home_30 { get; set; }
        public string WR_Home_31 { get; set; }
        public string WR_Home_32 { get; set; }
        public string WR_Home_23 { get; set; }
        public string WR_Home_13 { get; set; }
        public string WR_Home_03 { get; set; }
        public string WR_Away_30 { get; set; }
        public string WR_Away_31 { get; set; }
        public string WR_Away_32 { get; set; }
        public string WR_Away_23 { get; set; }
        public string WR_Away_13 { get; set; }
        public string WR_Away_03 { get; set; }
    }

}
