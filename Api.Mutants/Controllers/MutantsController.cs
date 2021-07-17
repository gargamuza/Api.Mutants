using Api.Mutants.Models;
using Api.Mutants.Models.Request;
using Api.Mutants.Repository;
using Api.Mutants.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Mutants.Models.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Mutants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutantsController : ControllerBase
    {
        IMutantsService _mutantsService;
        public MutantsController(IMutantsService mutantsService)
        {
            _mutantsService = mutantsService;
        }

        [HttpPost]
        [Route("/mutant")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public IActionResult IsMutant(MutantRequest adn)
        {
            var stat = (Stat)adn;
            var result = _mutantsService.IsMutant(adn.dna);
            stat.IsMutant = result;
           
            _mutantsService.SaveStat(stat);

            if (result)
                return Ok();
            else
                return StatusCode(403);
        }

        [HttpGet]
        [Route("/stats")]      
        [ProducesResponseType(typeof(StatsResponse), (int)HttpStatusCode.OK)]     
        public async Task<IActionResult> GetStats()
        {
            var stats = await _mutantsService.GetStats();

            return Ok((StatsResponse)stats);
        }
    }
}