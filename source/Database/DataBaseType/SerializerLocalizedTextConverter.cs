using System.Text.Json;
using AjKpi.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AjKpi.Database.DataBaseType;

public class SerializerLocalizedTextConverter :ValueConverter<LocalizedText, string>
{

    public SerializerLocalizedTextConverter()
        : base(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Convert to JSON string
            v => JsonSerializer.Deserialize<LocalizedText>(v, (JsonSerializerOptions)null)) // Convert from JSON string
    {
    }
}
