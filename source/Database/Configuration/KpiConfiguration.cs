namespace AjKpi.Database;

public class KpiConfiguration : IEntityTypeConfiguration<Kpi>
{
    public void Configure(EntityTypeBuilder<Kpi> builder)
    {
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(200);

        // builder.PrimitiveCollection(e => e.OrgUnit);
        // builder.PrimitiveCollection(e => e.Operation);
    }
}
