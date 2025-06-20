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
                return null;

            string valueStr = reader.Value.ToString();

            // Tenta parsear com ponto decimal (formato americano)
            if (decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            // Tenta com vírgula (formato brasileiro), se necessário
            if (decimal.TryParse(valueStr, NumberStyles.Any, new CultureInfo("pt-BR"), out result))
                return result;

            return null;
        }

        public override void WriteJson(JsonWriter writer, decimal? value, JsonSerializer serializer)
        {
            // Escreve como número puro (sem formatação)
            writer.WriteValue(value);
        }
    }
}
