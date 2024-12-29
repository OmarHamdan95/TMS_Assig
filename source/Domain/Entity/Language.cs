// using AjKpi.Domain.MarkarEntity;
//
// namespace AjKpi.Domain;
//
// public class Language : BaseAuditableEntity , IAggregateRoot
// {
//     public string? LangFlag { get; init; }
//
//     public virtual DateTime? ValidFrom { get; set; }
//     public virtual DateTime? ValidTo { get; set; }
//
//     public virtual bool IsActive
//     {
//         get { return (ValidFrom == null || DateTime.Now >= ValidFrom) && (ValidTo == null || DateTime.Now <= ValidTo); }
//     }
//     public Language(long id) => Id = id;
//
//     public Language(){}
//
//     public Language(string? code, string? langFlag)
//     {
//         Code = code;
//         LangFlag = langFlag;
//         ValidFrom = DateTime.Now;
//     }
//
//     public void Inactivate() => ValidTo = DateTime.Now.AddDays(-1);
// }
