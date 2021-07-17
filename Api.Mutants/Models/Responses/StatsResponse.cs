using Api.Mutants.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Mutants.Models.Responses
{
    public class StatsResponse
    {
        [JsonPropertyName("count_mutant_dna")]
        public int CountMutantDna { get; set; }

        [JsonPropertyName("count_human_dna")]
        public int CountHumanDna { get; set; }

        [JsonPropertyName("ratio")]
        [JsonConverter(typeof(CustomDoubleConverter))]
        public double Ratio { get; set; }

        public static explicit operator StatsResponse(StatCalculation v)
        {
            if (v == null)
                return null;

            return new StatsResponse
            {
                CountMutantDna = v.CountMutantDna,
                CountHumanDna = v.CountPersonDna,
                Ratio = v.Ratio,
            };
        }
    }
}
