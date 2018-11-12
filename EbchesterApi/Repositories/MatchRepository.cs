using EbchesterApi.Models;
using EbchesterApi.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private IMongoCollection<Match> _matchCollection;
        public MatchRepository(IMongoCollection<Match> matchCollection)
        {
            _matchCollection = matchCollection;
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _matchCollection
                .Find(x => x.MatchId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Match> AddMatchDetails(Match match)
        {
            await _matchCollection.InsertOneAsync(match);
            return match;
        }

        public async Task<List<Match>> GetResults()
        {
            return await _matchCollection
                .Find(x => x.Date < DateTime.Now)
                .SortByDescending(e => e.Date)
                .ToListAsync();
        }
        public async Task<List<Match>> GetFixtures()
        {
            return await _matchCollection
                .Find(x => x.Date >= DateTime.Now)
                .SortBy(e => e.Date)
                .ToListAsync();
        }
    }
}
