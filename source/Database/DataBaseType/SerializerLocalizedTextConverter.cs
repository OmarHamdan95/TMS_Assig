using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMS.Domain.Common;

namespace TMS.Database.DataBaseType;

public class SerializerLocalizedTextConverter :ValueConverter<LocalizedText, string>
{

    public SerializerLocalizedTextConverter()
        : base(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Convert to JSON string
            v => JsonSerializer.Deserialize<LocalizedText>(v, (JsonSerializerOptions)null)) // Convert from JSON string
    {
    }
}
