using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AjKpi.Database.DataBaseType;

public class DateUtcConverter : ValueConverter<DateTime, DateTime>
{
    public DateUtcConverter() : base(
        originalDate => DateTime.SpecifyKind(originalDate, DateTimeKind.Utc),
        targetDate => targetDate)
    {
    }
}

public class DateNullableUtcConverter : ValueConverter<DateTime?, DateTime?>
{
    public DateNullableUtcConverter() : base(
        originalDate => DateTime.SpecifyKind(originalDate ?? DateTime.Now, DateTimeKind.Utc),
        targetDate => targetDate)
    {
    }
}
