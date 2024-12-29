namespace AjKpi.Database;

public class RequestStatusesConfiguration: IEntityTypeConfiguration<RequestStatus>
{
    public void Configure(EntityTypeBuilder<RequestStatus> builder)
    {
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(200);


        builder.Property(e => e.IsStartingState)
            .IsRequired();

        builder.Property(e => e.IsEndState)
            .IsRequired();

        builder.PrimitiveCollection(e => e.Roles);
        builder.PrimitiveCollection(e => e.PreviousStatusCodes);
        builder.PrimitiveCollection(e => e.NextStatusCodes);

        builder.HasOne(e => e.RequestType)
            .WithMany(e => e.Statuses)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(e => e.RequestTypeId)
            .IsRequired();

        builder.HasIndex(e => new { e.Code, e.RequestTypeId })
            .IsUnique(true);
    }
}
