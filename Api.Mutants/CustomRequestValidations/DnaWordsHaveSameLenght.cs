using Api.Mutants.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.CustomRequestValidations
{
    public class DnaWordsHaveSameLenght : ValidationAttribute
    {    
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null || list.Count < 2)
                return false;
            
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i]?.ToString().Length >= 4 && list[i]?.ToString().Length != list[i + 1]?.ToString().Length)
                    return false;
            }               
            
            return true;
        }
    }
}

