using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Mutants.CustomRequestValidations
{
    public class StringsInCollectionOnlyHaveValidLetters : ValidationAttribute
    {
        private readonly string VALID_LETTERS;
        public StringsInCollectionOnlyHaveValidLetters(string validLetters, string errorMessage) : base(errorMessage)
        {
            VALID_LETTERS = validLetters;
        }
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null || list.Count == 0)
                return false;
                         
            foreach (var element in list)
            {
                var word = element as String;
                if (string.IsNullOrWhiteSpace(word))
                    return false;

                var result = word.All(c => VALID_LETTERS.Contains(c));
                if (!result)
                    return false;                  
            }
                      
            return true;
        }
    }
}