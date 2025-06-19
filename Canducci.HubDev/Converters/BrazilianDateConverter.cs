using Newtonsoft.Json;
using System;
using System.Globalization;
namespace Canducci.HubDev.Converters
{
    public class BrazilianDateConverter : JsonConverter<DateTime?>
    {
        public string DateFormat { get; }
        public BrazilianDateConverter(string dateFormat = "dd/MM/yyyy")
        {
            if (dateFormat is null)
            {
                throw new ArgumentNullException(nameof(dateFormat));
            }
            DateFormat = dateFormat;
        }

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            string dateStr = reader.Value.ToString();
            if (DateTime.TryParseExact(dateStr, DateFormat, CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var date))
            {
                return date;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value.ToString(DateFormat));
        }
    }
}
