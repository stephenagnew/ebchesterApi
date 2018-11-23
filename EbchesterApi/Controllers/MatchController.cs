using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbchesterApi.Models;
using EbchesterApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbchesterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchservice;
        public MatchController(IMatchService matchService)
        {
            _matchservice = matchService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            return Ok(await _matchservice.GetMatchById(id));
        }

        [HttpPost]
        public async Task<IActionResult>AddMatchDetails([FromBody] Match match)
        {
            return Ok(await _matchservice.AddMatchDetails(match));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchDetails([FromBody] Match match)
        {
            return Ok(await _matchservice.UpdateMatchDetails(match));
        }

        [HttpGet("results")]
        public async Task<IActionResult> GetResults()
        {
            return Ok(await _matchservice.GetResults());
        }

        [HttpGet("fixtures")]
        public async Task<IActionResult> GetFixtures()
        {
            return Ok(await _matchservice.GetFixtures());
        }
    }

}