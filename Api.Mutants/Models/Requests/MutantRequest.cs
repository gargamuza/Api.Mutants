using Api.Mutants.CustomRequestValidations;
using System.ComponentModel.DataAnnotations;

namespace Api.Mutants.Models.Request
{
    public class MutantRequest
    {
        [Required]
        [StringsInCollectionOnlyHaveValidLetters("ATCG", "Only the following letters are allowed: ATCG")]
        [StringsInCollectionHaveSameLenght(ErrorMessage = "The words that make up DNA must be the same length.")]
        public string[] dna { get; set; }
    }
}
