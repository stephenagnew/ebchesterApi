using EbchesterApi.Models;
using EbchesterApi.Repositories.Interfaces;
using EbchesterApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }

        public async Task<ResponseMessage> AddPlayer(Player player)
        {
            var addedPlayer = await _playerRepository.AddPlayer(player);
            return new ResponseMessage
            {
                Message = "Player Added Successfully",
                Body = addedPlayer
            };
        }

        public async Task<ResponseMessage> UpdatePlayer(Player player)
        {
            var updatePlayer = await _playerRepository.UpdatePlayer(player);
            if (updatePlayer)
                return new ResponseMessage
                {
                    Message = "Player Updated",
                    Body = player
                };
            else
            {
                return new ResponseMessage
                {
                    Message = "No Players have been modified"
                };
            }
        }

        public async Task<bool> UpdatePlayer(PlayerMatch playerMatch)
        {
            return await _playerRepository.UpdatePlayer(playerMatch);
        }

    }
}
