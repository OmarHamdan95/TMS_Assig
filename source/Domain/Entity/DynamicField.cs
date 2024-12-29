// using AjKpi.Domain.Common;
// using AjKpi.Domain.MarkarEntity;
//
// namespace AjKpi.Domain;
//
// public class DynamicField : BaseAuditableEntity , IAggregateRoot
// {
//     public LocalizedText? Name { get; set; }
//     private LookupValue? EntityType { get; set; }
//     public long? EntityTypeId { get; set; }
//     private LookupValue? DynamicFieldType { get; set; }
//     public long? DynamicFieldTypeId { get; set; }
//     public string? DynamicFieldRegex { get; set; }
//     public long? DynamicFieldMinValue { get; set; }
//     public long? DynamicFieldMaxValue { get; set; }
//     private LookupValue? DynamicFieldLookupType { get; set; }
//     public long? DynamicFieldLookupTypeId { get; set; }
//
//
//     public DynamicField()
//     {
//     }
//
//     public DynamicField(long id) => Id = id;
//
//     public DynamicField(LocalizedText? name, LookupValue? entityType, LookupValue? dynamicFieldType,
//         string? dynamicFieldRegex, long? dynamicFieldMinValue, long? dynamicFieldMaxValue,
//         LookupValue? dynamicFieldLookupType)
//     {
//         Name = name;
//         EntityTypeId = entityType?.Id ?? null;
//         DynamicFieldTypeId = dynamicFieldType?.Id ?? null;
//         DynamicFieldRegex = dynamicFieldRegex;
//         DynamicFieldMinValue = dynamicFieldMinValue;
//         DynamicFieldMaxValue = dynamicFieldMaxValue;
//         DynamicFieldLookupTypeId = dynamicFieldLookupType?.Id ?? null;
//     }
//
//
//     public void UpdateDynamicField(LocalizedText? name, LookupValue? entityType, LookupValue? dynamicFieldType,
//         string? dynamicFieldRegex, long? dynamicFieldMinValue, long? dynamicFieldMaxValue,
//         LookupValue? dynamicFieldLookupType)
//     {
//         Name = name;
//         EntityTypeId = entityType?.Id ?? null;
//         DynamicFieldTypeId = dynamicFieldType?.Id ?? null;
//         DynamicFieldRegex = dynamicFieldRegex;
//         DynamicFieldMinValue = dynamicFieldMinValue;
//         DynamicFieldMaxValue = dynamicFieldMaxValue;
//         DynamicFieldLookupTypeId = dynamicFieldLookupType?.Id ?? null;
//     }
// }
