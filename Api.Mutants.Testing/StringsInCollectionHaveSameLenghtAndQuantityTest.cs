using Api.Mutants.CustomRequestValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    public class StringsInCollectionHaveSameLenghtAndQuantityTest
    {
        [DataRow(new string[] { "AB", "AB" }, true)]
        [DataRow(new string[] { "ABC", "ABC", "EFG" }, true)]
        [DataRow(new string[] { "ABCD", "ABCD", "EFGD" }, false)]
        [DataRow(new string[] { "ABCD" }, false)]
        [DataRow(new string[] { }, false)]
        [DataRow(null, false)]
        [TestMethod]
        public void IsValid_StringsInCollectionHaveSameLenghtAndQuantity(string[] array, bool expected)
        {
            //Arrange
            var stringsInCollectionHaveSameLenghtAndQuantity = new StringsInCollectionHaveSameLenghtAndQuantity();

            //Act
            var result = stringsInCollectionHaveSameLenghtAndQuantity.IsValid(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
