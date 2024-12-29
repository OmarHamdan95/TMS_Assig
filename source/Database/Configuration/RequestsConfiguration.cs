namespace AjKpi.Database;

public class RequestsConfiguration: IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder
            .Property(e => e.ExternalId)
            .IsRequired();

        builder
            .HasOne(e => e.Status)
            .WithMany()
            .HasForeignKey(e => e.StatusId)
            .IsRequired();

        builder
            .HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey(e => e.TypeId)
            .IsRequired();

        builder.PrimitiveCollection(e => e.CompositeKeys);
        builder.PrimitiveCollection(e => e.GlobalCompositeKeys);


        builder.HasIndex(e => e.Number)
            .IsUnique(false);
    }
}
