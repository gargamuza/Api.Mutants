using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.CustomRequestValidations
{
    public class StringsInCollectionHaveMinimumLenght : ValidationAttribute
    {
        private readonly int MINIMUN_LENGHT;
        public StringsInCollectionHaveMinimumLenght(int minimumLenght, string errorMessage) : base(errorMessage)
        {
            MINIMUN_LENGHT = minimumLenght;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null || list.Count < 2)
                return false;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i]?.ToString().Length < MINIMUN_LENGHT)
                    return false;
            }

            return true;
        }
    }
}