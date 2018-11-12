using EbchesterApi.Models;
using EbchesterApi.Repositories.Interfaces;
using EbchesterApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRespository;
        public MatchService(IMatchRepository matchRepository, IPlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _playerRespository = playerRepository;
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _matchRepository.GetMatchById(id);
        }

        public async Task<ResponseMessage> AddMatchDetails(Match match)
        {
            var addedMatch = await _matchRepository.AddMatchDetails(match);

            //Update Player Stats here with info from match report
            foreach (var playerMatch in addedMatch.PlayerMatchStats)
            {
                _playerRespository.UpdatePlayer(playerMatch);
            }

            return new ResponseMessage
            {
                Message = "Match Added Successfully",
                Body = addedMatch
            };
        }

        public async Task<List<Match>> GetResults()
        {
            return await _matchRepository.GetResults();
        }

        public async Task<List<Match>> GetFixtures()
        {
            return await _matchRepository.GetFixtures();
        }
    }
}
