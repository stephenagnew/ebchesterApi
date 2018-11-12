using EbchesterApi.Models;
using EbchesterApi.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IMongoCollection<Player> _playerCollection;
        public PlayerRepository(IMongoCollection<Player> playerCollection)
        {
            _playerCollection = playerCollection;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _playerCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<Player> AddPlayer(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<bool> UpdatePlayer(Player player)
        {
            var result = await _playerCollection
                .ReplaceOneAsync(x => x.PlayerId == player.PlayerId, player);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> UpdatePlayer(PlayerMatch playerMatch)
        {
            var result = await _playerCollection
                .UpdateOneAsync(x => x.PlayerId == playerMatch.PlayerId, 
                Builders<Player>.Update
                .Inc(y => y.PlayerSeasonStats.Appearance, playerMatch.Appearance)
                .Inc(y => y.PlayerSeasonStats.Goals, playerMatch.Goals)
                .Inc(y => y.PlayerSeasonStats.Assists, playerMatch.Assists)
                .Inc(y => y.PlayerSeasonStats.Mom, playerMatch.Mom)
                );

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

    }
}
