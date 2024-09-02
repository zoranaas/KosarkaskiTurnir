using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Models
{
    public class Grupa
    {
        public string  Ime { get; set; }
        public List<Team> Timovi { get; set; } = new List<Team>();
        public List<Match> Matches { get; set; } = new List<Match>();

        public Grupa(string ime, List<Team> timovi)
        {
            Ime = ime;
            Timovi= timovi;
        }

        public Grupa()
        {
            
        }


    }
}
