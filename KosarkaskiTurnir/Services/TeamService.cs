using KosarkaskiTurnir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Services
{
    public class TeamService
    {
        public void UpdateTeam(Team team, int postignuti, int primljeni, bool pobjeda )
        {
            team.PostignutiGolovi += postignuti;
            team.PrimljeniGolovi += primljeni;

            if (pobjeda)
            {
                team.Pobjede++;
                team.Bodovi += 2;
            }
            else
            {
                team.Izgubljeno++;
                team.Bodovi += 1;
            }
        }

    }
}
