// using AjKpi.Domain.MarkarEntity;
//
// namespace AjKpi.Domain;
//
// public class Translation : BaseAuditableEntity , IAggregateRoot
// {
//     // public string? Code { get; set; }
//
//     private List<TranslationValue> _translationValues = new List<TranslationValue>();
//     public virtual IReadOnlyCollection<TranslationValue> TranslationValues =>
//         _translationValues.AsReadOnly();
//     //public List<TranslationValue>? TranslationValues { get; private set; }
//
//     public Translation(){}
//
//     public Translation(long id) => Id = id;
//
//     public Translation(List<TranslationValue> translationValues) => _translationValues = translationValues;
//
//     public Translation(string code, List<TranslationValue> translationValues)
//     {
//         _translationValues = translationValues;
//         Code = code;
//     }
//
//     public void UpdateTranslation(List<TranslationValue> translationValues)
//     {
//         _translationValues = translationValues;
//     }
//
//
//
// }
