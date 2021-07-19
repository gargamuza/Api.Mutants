using Api.Mutants.CustomRequestValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    public class StringsInCollectionHaveSameLenghtTest
    {
        [DataRow(new string[] { "ABCD", "ABC", "EFGB" }, false)]       
        [DataRow(new string[] { "ABCDDD", "ABCDDD", "EFGBED" }, true)]
        [DataRow(new string[] { "ABCD" }, false)]
        [DataRow(new string[] { }, false)]
        [DataRow(null, false)]
        [TestMethod]
        public void IsValid_StringsInCollectionHaveSameLenght(string[] array, bool expected)
        {
            //Arrange
            var stringsInCollectionHaveSameLenght = new StringsInCollectionHaveSameLenght();

            //Act
            var result = stringsInCollectionHaveSameLenght.IsValid(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
