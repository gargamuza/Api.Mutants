using Api.Mutants.Models.Request;
using Api.Mutants.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            var result = _mutantsService.IsMutant(adn.dna);
            if (result)
                return Ok();
            else
                return Forbid();
        }      
    }
}
