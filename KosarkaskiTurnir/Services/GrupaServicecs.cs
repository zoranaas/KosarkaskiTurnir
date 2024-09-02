using KosarkaskiTurnir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Services
{
    public class GrupaServicecs
    {
        private readonly MatchService _matchService;

        public GrupaServicecs(MatchService matchService)
        {
            _matchService = matchService;
        }


        public void GrupniMecevi(Grupa grupa)
        {
            for(int i=0; i< grupa.Timovi.Count; i++)
            {
                for(int j=i +1; j< grupa.Timovi.Count; j++)
                {
                    grupa.Matches.Add(new Match(grupa.Timovi[i], grupa.Timovi[j]));
                }
            }
        }

        public void IgraGrupnihMeceva(Grupa grupa)
        {
            foreach(var item in grupa.Matches)
            {
                _matchService.IgraMatch(item);
            }
        }

        public List<Team> RangTimova(Grupa grupa)
        {
            return grupa.Timovi.OrderByDescending(m=>m.Bodovi)
                               .ThenByDescending(m=>m.RazlikaGolova)
                               .ThenByDescending(m=>m.PostignutiGolovi)
                               .ToList();
        }
    }
}
