using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbchesterApi.Models;
using EbchesterApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbchesterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _playerService.GetPlayers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayers(int playerId)
        {
            return Ok(await _playerService.GetPlayerById(playerId));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] Player player)
        {
            return Ok(await _playerService.AddPlayer(player));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer([FromBody] Player player)
        {
            return Ok(await _playerService.UpdatePlayer(player));
        }
    }
}