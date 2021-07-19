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
        [DataRow(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"}, true)]
        [DataRow(new string[] { "ABCDEF", "GHIJKL", "LMNOPQ", "QRSTUV", "WXYZAB", "CDEFGH" }, false)]
        [TestMethod]
        public void IsMutant_ValidateMutantDNA(string[] array, bool expected) 
        {
            //Arrange
            var mutantsService = new MutantsService();
                               
            //Act
            var result = mutantsService.IsMutant(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
