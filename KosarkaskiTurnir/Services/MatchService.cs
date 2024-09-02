using KosarkaskiTurnir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaskiTurnir.Services
{
    public class MatchService
    {
        private readonly TeamService _teamService;

        public MatchService(TeamService teamService)
        {
            _teamService = teamService;
        }

        public void IgraMatch(Match match)
        {
            if (!match.Igrali)
            {
                var rand = new Random();

                int razlikaBodova = match.TeamB.FibaRanking - match.TeamA.FibaRanking;

                match.TeamABodovi = rand.Next(80, 100) + razlikaBodova;
                match.TeamBBodovi = rand.Next(75, 90) - razlikaBodova;

                bool teamPobjeda = match.TeamABodovi > match.TeamBBodovi;

                _teamService.UpdateTeam(match.TeamA, match.TeamABodovi, match.TeamBBodovi, teamPobjeda);
                _teamService.UpdateTeam(match.TeamB, match.TeamBBodovi, match.TeamABodovi, !teamPobjeda);

                match.Igrali = true;
            }
        }




    }
}
