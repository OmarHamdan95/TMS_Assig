//using TMS.Domain;

//namespace TMS.Database;

//public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
//{
//    public void Configure(EntityTypeBuilder<Role> builder)
//    {
//        // builder.ToTable(nameof(Auth), nameof(Auth));

//        builder.HasKey(entity => entity.Id);

//        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();


//        builder.HasMany(entity => entity.Permissions).WithOne().HasForeignKey("RoleId").IsRequired();

//    }
//}
