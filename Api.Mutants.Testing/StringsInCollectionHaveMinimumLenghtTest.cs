using Api.Mutants.CustomRequestValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Mutants.Testing
{
    [TestClass]
    class StringsInCollectionHaveMinimumLenghtTest
    {
        [TestMethod]
        public void TestIsValid_AtLeastOneElementIsLessThatMinimun()
        {
            //Arrange
            var stringsInCollectionHaveMinimumLenght = new StringsInCollectionHaveMinimumLenght(4, "");
            var array = new string[] { "ABCD", "ABC", "EFGB" };

            //Act
            var result = stringsInCollectionHaveMinimumLenght.IsValid(array);

            //Fact
            Assert.IsFalse(result);
        }
    }
}
