using Api.Mutants.CustomRequestValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    public class StringsInCollectionOnlyHaveValidLettersTest
    {
        [DataRow(new string[] { "ATCG", "ATCG" }, "ATCG", true)]
        [DataRow(new string[] { "ATCGZ", "ATCG", "ATCG" }, "ATCG", false)]
        [DataRow(new string[] { "", "ATCG", "ATCG" }, "ATCG", false)]
        [DataRow(new string[] { "AAAA" }, "ATCG", true)]
        [DataRow(new string[] { }, "ATCG", false)]
        [DataRow(null, "ATCG", false)]
        [TestMethod]
        public void IsValid_StringsInCollectionHaveSameLenghtAndQuantity(string[] array, string pattern, bool expected)
        {
            //Arrange
            var stringsInCollectionOnlyHaveValidLetters = new StringsInCollectionOnlyHaveValidLetters(pattern, "");

            //Act
            var result = stringsInCollectionOnlyHaveValidLetters.IsValid(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
