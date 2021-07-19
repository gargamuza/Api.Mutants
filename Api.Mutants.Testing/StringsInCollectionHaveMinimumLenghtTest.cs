using Api.Mutants.CustomRequestValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    public class StringsInCollectionHaveMinimumLenghtTest
    {      
        [DataRow(new string[] { "ABCD", "ABC", "EFGB" }, 4, false)]
        [DataRow(new string[] { "ABCD", "ABCD", "EFGB" }, 4, true)]
        [DataRow(new string[] { "ABCDDD", "ABCDDD", "EFGBED" }, 5, true)]
        [DataRow(new string[] { "ABCDDD" }, 5, false)]
        [DataRow(new string[] { }, 5, false)]
        [DataRow(null, 5, false)]
        [TestMethod]
        public void IsValid_StringsInCollectionHaveValidMinimumLenght(string[] array, int minimumLenght, bool expected)
        {
            //Arrange
            var stringsInCollectionHaveMinimumLenght = new StringsInCollectionHaveMinimumLenght(minimumLenght, "");         

            //Act
            var result = stringsInCollectionHaveMinimumLenght.IsValid(array);

            //Fact         
            Assert.AreEqual(result, expected);
        }
    }
}
