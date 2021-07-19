using Api.Mutants.Repository;
using Api.Mutants.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    public class MutantsServiceTest
    {
        [DataRow(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"}, true)] //Horizontal, Vertical, Diagonal
        [DataRow(new string[] { "ABCDEF", "GHIJKL", "LMNOPQ", "QRSTUV", "WXYZAB", "CDEFGH" }, false)]
        [DataRow(new string[] { "ATGCGA", "CAGTGC", "TTGTGT", "AGAGTT", "CCGCGA", "TCACTG" }, true)] //Diagonal 1 G      
        [TestMethod]
        public void IsMutant_ValidateMutantDNA(string[] array, bool expected) 
        {
            //Arrange
            var mutantsService = new MutantsService(new Configuration.DnaOptions {MutantOcurrences = 4 });
                               
            //Act
            var result = mutantsService.IsMutant(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
