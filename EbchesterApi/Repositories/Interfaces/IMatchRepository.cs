using EbchesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> GetMatchById(int id);
        Task<Match> AddMatchDetails(Match match);
        Task<bool> UpdateMatchDetails(Match match);
        Task<List<Match>> GetResults();
        Task<List<Match>> GetFixtures();
    }
}
