using EbchesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Services.Interfaces
{
    public interface IMatchService
    {
        Task<Match> GetMatchById(int id);
        Task<ResponseMessage> AddMatchDetails(Match match);
        Task<List<Match>> GetResults();
        Task<List<Match>> GetFixtures();
    }
}
