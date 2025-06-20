using Newtonsoft.Json;
using System;
using System.Globalization;
namespace Canducci.HubDev.Converters
{
    public class BrazilianDecimalConverter : JsonConverter<decimal?>
    {
        public override decimal? ReadJson(JsonReader reader, Type objectType, decimal? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            if (reader.Value is decimal decimalValue)
            {
                return decimalValue;
            }
            if (reader.Value is double doubleValue)
            {
                return (decimal)doubleValue;
            }
            if (reader.Value is float floatValue)
            {
                return (decimal)floatValue;
            }
            if (reader.Value is long longValue)
            {
                return longValue;
            }
            if (reader.Value is int intValue)
            {
                return intValue;
            }
            string valueStr = reader.Value.ToString();
            if (decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }
            if (decimal.TryParse(valueStr, NumberStyles.Any, new CultureInfo("pt-BR"), out result))
            {
                return result;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, decimal? value, JsonSerializer serializer)
        {
            // Escreve como número puro (sem formatação)
            writer.WriteValue(value);
        }
    }
}
