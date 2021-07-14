using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.CustomRequestValidations
{
    public class StringsInCollectionHaveSameLenghtAndQuantity : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null || list.Count < 2)
                return false;

            var count = list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]?.ToString().Length != count)
                    return false;
            }

            return true;
        }
    }
}
