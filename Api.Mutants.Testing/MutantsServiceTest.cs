using Api.Mutants.Helpers;
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
        [DataRow(new string[] { "TTGCGA", "CAGTGC", "TTATGT", "AGAAAG", "CCTCTA", "TCACTG" }, false)]
        [DataRow(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" }, true)] //Diagonal A
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

        [DataRow(new string[] { "TTGCGA","CAGTGC","TTATAT","AGAAGG","CCCCTA","TCACTG" }, true)]
        [DataRow(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCTCTA", "TCACTG" }, false)]
        [TestMethod]
        public void IsMutant_ValidateMutantHorizontalDNASearch(string[] array, bool expected)
        {
            //Arrange
            var mutantsService = new MutantsService(new Configuration.DnaOptions { MutantOcurrences = 4 });
            var multiArray = ArraysHelper.ConvertToMultiArray(array);

            //Act
            var result = mutantsService.DnaHorizontalSearch(multiArray);

            //Fact         
            Assert.AreEqual(result, expected);
        }

        [DataRow(new string[] { "TTGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCACTA", "TCACTG" }, true)] 
        [DataRow(new string[] { "TTGCGA", "CAGTGC", "TTCTCT", "AGAAGG", "CCACTA", "TCACTG" }, false)]
        [TestMethod]
        public void IsMutant_ValidateMutantVerticalDNASearch(string[] array, bool expected)
        {
            //Arrange
            var mutantsService = new MutantsService(new Configuration.DnaOptions { MutantOcurrences = 4 });
            var multiArray = ArraysHelper.ConvertToMultiArray(array);

            //Act
            var result = mutantsService.DnaVerticalSearch(multiArray);

            //Fact         
            Assert.AreEqual(result, expected);
        }

        [DataRow(new string[] { "ATGCCA", "CAGTGC", "TTATGT", "AGAAGG", "TCCCTA", "TCACTG" }, true)] //Diagonal Inferior
        [DataRow(new string[] { "TTGCCA", "CAGGGC", "TTATGT", "AGAAGG", "TCCCTA", "TCACTG" }, true)] // Diagonal Superior
        [DataRow(new string[] { "TTGCGA", "CAGTGC", "TTCTCT", "AGAAGG", "CCACTA", "TCACTG" }, false)]
        [TestMethod]
        public void IsMutant_ValidateMutantDiagonalDNASearch(string[] array, bool expected)
        {
            //Arrange
            var mutantsService = new MutantsService(new Configuration.DnaOptions { MutantOcurrences = 4 });
            var multiArray = ArraysHelper.ConvertToMultiArray(array);

            //Act
            var result = mutantsService.DnaDiagonalSearch(multiArray);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
