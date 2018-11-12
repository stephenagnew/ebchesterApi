using EbchesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
       Task<List<Player>> GetPlayers();
        Task<Player> AddPlayer(Player player);
        Task<bool> UpdatePlayer(Player player);
        Task<bool> UpdatePlayer(PlayerMatch playerMatch);
    }
}
