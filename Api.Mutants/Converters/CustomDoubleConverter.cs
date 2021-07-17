
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Mutants.Converters
{

    public class CustomDoubleConverter : JsonConverter<double>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(double);
        }

        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Math.Round(value, 2));
        }
    }

}
