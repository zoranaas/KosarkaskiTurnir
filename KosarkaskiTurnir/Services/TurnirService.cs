using KosarkaskiTurnir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Services
{
    public class TurnirService
    {
        private readonly GrupaServicecs _grupaService;
        private readonly List<Grupa> _grupe;


        public TurnirService(GrupaServicecs grupaService, List<Grupa> grupe )
        {
            _grupaService = grupaService;
            _grupe= grupe;
        }

        public void IgraTurnira()
        {
            foreach(var item in _grupe)
            {
                _grupaService.GrupniMecevi(item);
                _grupaService.IgraGrupnihMeceva(item);
            }
        }


        public void PrikazRezultata()
        {
            foreach(var grupa in _grupe)
            {
                Console.WriteLine($"\nGrupa {grupa.Ime}, rezultati: ");
                foreach(var match in grupa.Matches)
                {
                    Console.WriteLine($"{match.TeamA.Ime} -  {match.TeamB.Ime} ({match.TeamABodovi}) : ({match.TeamBBodovi})");
                }

                Console.WriteLine($"\nKonacni plasman u grupama:\n \tRangiranje u grupi {grupa.Ime}: Ime - pobede / porazi/ bodovi/ postignuti golovi/ primljeni golovi/ razlika golova");
                var rangirani = _grupaService.RangTimova(grupa);
                for (int i = 0; i < rangirani.Count; i++)
                {
                    var team = rangirani[i];
                    Console.WriteLine($"\t\t{i + 1}. {team.Ime} \t{team.Pobjede} / \t{team.Izgubljeno} / \t{team.Bodovi} / \t{team.PostignutiGolovi} / \t{team.PrimljeniGolovi} / \t{team.RazlikaGolova}");
                }

            }

        }


        public List<Team> Top3()
        {
            var top = new List<Team>();
            foreach(var grupa in _grupe)
            {
                var rangTeam = _grupaService.RangTimova(grupa);
                top.AddRange(rangTeam.Take(3));
            }

            return top.OrderBy(m => m.Bodovi)
                      .ThenBy(m => m.RazlikaGolova)
                      .ThenBy(m => m.PrimljeniGolovi)
                      .Take(8)
                      .ToList();
        }
    }
}
