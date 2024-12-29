using AjKpi.Domain;

namespace AjKpi.Database;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.ToTable(nameof(User), nameof(User));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.NameAr).HasMaxLength(250).IsRequired();
        builder.Property(entity => entity.NameEn).HasMaxLength(250).IsRequired();
        builder.Property(entity => entity.MobileNumber).HasMaxLength(250).IsRequired();
        builder.Property(entity => entity.DepartmentId).IsRequired();

        builder.Property(entity => entity.Email).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Status).IsRequired();

        builder.HasIndex(entity => entity.Email).IsUnique();
    }
}
