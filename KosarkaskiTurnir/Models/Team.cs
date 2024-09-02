using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Models
{
    public class Team
    {

        public string Ime { get; set; }
        public string IsoCode { get; set; }
        public int FibaRanking { get; set; }
        public int Bodovi { get; set; } 
        public int PostignutiGolovi { get; set; }
        public int PrimljeniGolovi { get; set; }
        public int Pobjede { get; set; }
        public int Izgubljeno { get; set; }
        public int RazlikaGolova => PostignutiGolovi - PrimljeniGolovi;


        public Team()
        {
            
        }

        public Team(string ime, string isoCode, int fibaRanking)
        {
            Ime = ime; 
            IsoCode= isoCode;
            FibaRanking = fibaRanking;  
        }
    }
}
