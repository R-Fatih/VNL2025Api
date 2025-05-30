using System.Text;

namespace VNL2025Api.Entities
{
    public class Set
    {
        public int no { get; set; }
        public int pointsTeamA { get; set; }
        public int pointsTeamB { get; set; }
        public override string ToString()
        {
            if(pointsTeamA==0&&pointsTeamB==0)
                return "-";
            return  pointsTeamA+"-"+ pointsTeamB;
        }
    }

}
