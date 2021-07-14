using Api.Mutants.CustomRequestValidations;
using System.ComponentModel.DataAnnotations;

namespace Api.Mutants.Models.Request
{
    public class MutantRequest
    {
        [Required]
        [StringsInCollectionOnlyHaveValidLetters("ATCG", "Only the following letters are allowed: ATCG")]
        [StringsInCollectionHaveSameLenght(ErrorMessage = "The words that make up DNA must be the same length.")]
        [StringsInCollectionHaveMinimumLenght(4, "The words that make up the DNA must be at least 4 characters long")]
        [StringsInCollectionHaveSameLenghtAndQuantity(ErrorMessage = "The words that make up the DNA must have the same length as the number of words")]
        public string[] dna { get; set; }
    }
}
