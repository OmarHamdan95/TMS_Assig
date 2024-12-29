using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json;
using AjKpi.Database.DataBaseType;
using AjKpi.Domain.Common;
using AjKpi.Domain.MarkarEntity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AjKpi.Database.Common;

public static class ModelBuilderExtensions
{
    public static void ApplyConvention(this ModelBuilder modelBuilder, List<Type> types, string schemaName)
    {
        foreach (var type in types)
        {
            var entityConfig = modelBuilder.Entity(type);

            entityConfig.ToTable(type.ToUpperUnderscoreTableName(), schemaName);

            if (type.IsAssignableTo(typeof(ISoftDeletable)))
                entityConfig.AddSoftDeleteQueryFilter(type);


            var typeProperties = type.GetProperties();


            foreach (var property in typeProperties)
            {
                if (property.PropertyType.IsSubclassOf(typeof(ValueObject)))
                    entityConfig.OwnsOne(property.PropertyType, property.Name);



                if (property.PropertyType == typeof(LocalizedText))
                    entityConfig.Property(property.Name).HasConversion<SerializerLocalizedTextConverter>().HasColumnType("nvarchar(max)");

                // if (property.PropertyType.GetAttributes<NotMappedAttribute>().IsNotNull())
                //     continue;

                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    entityConfig.Property(property.PropertyType, property.Name)
                        .HasConversion<DateUtcConverter>();
            }
        }
    }
}

public static class SoftDeleteQueryExtension
{
    public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(
                nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static
            )
            .MakeGenericMethod(entityData.ClrType);
        var filter = methodToCall.Invoke(null, new object[] { });
        entityData.SetQueryFilter((LambdaExpression)filter);
    }

    public static void AddSoftDeleteQueryFilter(this EntityTypeBuilder entityTypeBuilder, Type clrType)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension).GetMethod(
                nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static
            )
            .MakeGenericMethod(clrType);


        var filter = methodToCall.Invoke(null, new object[] { });
        entityTypeBuilder.HasQueryFilter((LambdaExpression)filter);
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, ISoftDeletable
    {
        Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
        return filter;
    }


    // public static EntityTypeBuilder HasLocalizedText<TEntity>(this EntityTypeBuilder builder,
    //     Expression<Func< IEnumerable<Localization>>> property)
    // {
    //     builder.Property(property).HasColumnType("jsonb");
    //
    //     return builder;
    // }
}
