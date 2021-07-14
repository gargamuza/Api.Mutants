using Api.Mutants.Models.Request;
using Api.Mutants.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult IsMutant(MutantRequest adn)
        {
            var result = _mutantsService.IsMutant(adn.dna);
            if (result)
                return Ok();
            else
                return Forbid();
            //string[,] array = ConvertToMultiArray(adn.dna);

            ////Busqueda Horizontal
            //for (int i = 0; i < array.GetLength(0) - 1; i++)
            //{
            //    int iOcurrencias = 0;

            //    for (int j = 0; j < array.GetLength(1) - 1; j++)
            //    {
            //        if (array[i, j] == array[i, j + 1])
            //            iOcurrencias++;
            //        else
            //            iOcurrencias = 0;

            //        if (iOcurrencias == 3)
            //        {
            //            Console.WriteLine("Mutante");
            //            return Ok();
            //        }

            //    }
            //}

            ////Busqueda Vertical
            //for (int j = 0; j < array.GetLength(1) - 1; j++)
            //{
            //    int iOcurrencias = 0;

            //    for (int i = 0; i < array.GetLength(0) - 1; i++)
            //    {
            //        if (array[i, j] == array[i + 1, j])
            //            iOcurrencias++;
            //        else
            //            iOcurrencias = 0;

            //        if (iOcurrencias == 3)
            //        {
            //            Console.WriteLine("Mutante");
            //            return Ok();
            //        }
            //    }
            //}

            ////Busqueda Diagonal
            //for (int i = 0; i < array.GetLength(0) - 1; i++)
            //{
            //    int iOcurrencias = 0;

            //    for (int j = 0; j < array.GetLength(1) - 1; j++)
            //    {
            //        if (array[i, j] == array[++i, j + 1])
            //            iOcurrencias++;
            //        else
            //            iOcurrencias = 0;

            //        if (iOcurrencias == 3)
            //        {
            //            Console.WriteLine("Mutante");
            //            return Ok();
            //        }
            //    }
            //}

            //Console.WriteLine("No Mutante");
            //return Forbid();
        }

        private string[,] ConvertToMultiArray(string[] adn)
        {
            string[,] arr = new string[adn.Length, adn.Max(s => s.Length)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = adn[i].Substring(j, 1);
                }
            }

            return arr;
        }
    }
}
