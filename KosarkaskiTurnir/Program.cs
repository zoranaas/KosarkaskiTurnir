using KosarkaskiTurnir.Models;
using KosarkaskiTurnir.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace KosarkaskiTurnir
{
    public class Program
    {
        static void Main(string[] args)
        {
            var grupaA = new Grupa("A", new List<Team>
            {
                    new Team("Kanada", "Kan", 7  ),
                    new Team("Australija", "Aus", 5),
                    new Team("Grcka", "GRE", 14),
                    new Team("Spanija", "ESP", 2)
                });

            var grupaB = new Grupa("B", new List<Team>
            {
                    new Team("Njemacka", "GER", 3),
                    new Team("Francuska", "Fra", 9),
                    new Team("Brazil", "Bra", 12),
                    new Team("Japan", "Jpn", 26)
            });

            var grupaC = new Grupa("C", new List<Team>
            {
                new Team("Sjedinjenje drzave", "USA", 1),
                new Team("Srbija", "Srb", 4),
                new Team("Juzni Sudan", "SSD", 34),
                new Team("Puerto Riko", "Pri", 16)
            }) ;

            var teamService = new TeamService();
            var matchService = new MatchService(teamService);

            var groupService = new GrupaServicecs(matchService);
            var tournamentService = new TurnirService(groupService, new List<Grupa> { grupaA, grupaB, grupaC});

            tournamentService.IgraTurnira();
            tournamentService.PrikazRezultata();

            var topTeams = tournamentService.Top3();
            Console.WriteLine("\nRangiranje:");
            foreach (var team in topTeams)
            {
                Console.WriteLine($"{team.Ime} ({team.IsoCode}) - Rank: {team.Bodovi}");
            }


            Console.ReadKey();


        }
    }
}
