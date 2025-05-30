using VNL2025Api.Controllers;
using VNL2025Api.Entities;

namespace VNL2025Api.Services
{
    public class WikiFormatterService
    {
        
        public  List<string> FormatMatch(List<MatchWiki> matches)
        {
            List<string> formattedStrings = new();
            string baseFormat = "|{12}-{0}-{1} =  \n{{{{vb res 51\r\n| takım1 ={{{{vb-rt|{0}}}}}\r\n| takım2 ={{{{vb|{1}}}}}\r\n| tarih = {2}\r\n| zaman = {3}\r\n| sonuç = {4}\r\n| set1  = {5}\r\n| set2  = {6}\r\n| set3  = {7}\r\n| set4  = {8}\r\n| set5  = {9}\r\n| rapor = {10} [{11} Rapor]\r\n| bc    = \r\n}}}}\n";
            matches.ForEach(x =>
            {
                string p2Part = string.IsNullOrWhiteSpace(x.P2Report) ? "" : $"[{x.P2Report} P2 ] ";
                var formatted = string.Format(baseFormat,
                    x.HomeTeam,
                    x.AwayTeam,
                    x.Date.ToString("dd MMMM"),
                    x.Date.ToString("HH.mm"),
                   x.MatchStatus==2? $"{x.HomeScore}-{x.AwayScore}":"-",
                    x.Sets[0].ToString(),
                    x.Sets[1].ToString(),
                    x.Sets[2].ToString(),
                    x.Sets[3].ToString()=="-"?"": x.Sets[3].ToString(),
                    x.Sets[4].ToString() == "-" ? "" : x.Sets[4].ToString(),
                    p2Part,
                    x.Report ?? "",
                    x.RoundName);
                formattedStrings.Add(formatted);
            });

            return formattedStrings;
        }
     
    }
}
