using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Models
{
    public class Match
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public int TeamABodovi { get; set; }
        public int TeamBBodovi { get; set; }
        public bool Igrali { get; set; } = false;


        public Match()
        {
            
        }

        public Match(Team teamA, Team teamB)
        {
            TeamA = teamA;
            TeamB= teamB;
        }


    }
}
