namespace AjKpi.Database;

public class RequestTypesConfiguration : IEntityTypeConfiguration<RequestType>
{
    public void Configure(EntityTypeBuilder<RequestType> builder)
    {

        builder.PrimitiveCollection(e => e.ConcurrencyPreventedTypeCodes);

        builder
            .Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(e => e.PreventConcurrentRequests)
            .IsRequired();

        builder
            .HasIndex(e => e.Code)
            .IsUnique(true);

        builder.OwnsMany(e => e.SearchEntries,
            navigationBuilder => { navigationBuilder.ToTable("RequestTypeSearchEntries"); });
    }
}
