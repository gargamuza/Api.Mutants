using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Mutants.CustomRequestValidations
{
    public class DnaHaveValidLetters : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null)
                return false;
                         
            foreach (var element in list)
            {
                var word = element as String;
                if (string.IsNullOrWhiteSpace(word))
                    return false;

                var result = word.All(c => "ATCG".Contains(c));
                if (!result)
                    return false;                  
            }
                      
            return true;
        }
    }
}