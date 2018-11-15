using EbchesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayers();
        Task<Player> GetPlayerById(int playerId);
        Task<ResponseMessage> AddPlayer(Player player);
        Task<ResponseMessage> UpdatePlayer(Player player);
        Task<bool> UpdatePlayer(PlayerMatch playerMatch);
    }
}
