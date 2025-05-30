namespace VNL2025Api.Entities
{
    public class Standing
    {
        public int TeamNo { get; set; }
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Win3_0 { get; set; }
        public int Win3_1 { get; set; }
        public int Win3_2 { get; set; }
        public int Loss0_3 { get; set; }
        public int Loss1_3 { get; set; }
        public int Loss2_3 { get; set; }
        public int Points => ((Win3_0+ Win3_1)* 3) + Win3_2 * 2 + Loss2_3 * 1;
        public int SetsWin { get; set; }
        public int SetsLoss { get; set; }
        public double SetsRatio => Math.Round((double)SetsWin / SetsLoss, 3);
        public int PointsWin { get; set; }
        public int PointsLoss { get; set; }
        public double PointsRatio => Math.Round((double)PointsWin / PointsLoss, 3);

    }
}
