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
        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _matchRepository.GetMatchById(id);
        }

        public async Task<ResponseMessage> AddMatchDetails(Match match)
        {
            var addedMatch = await _matchRepository.AddMatchDetails(match);

            //Update Player Stats here with info from match report

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
