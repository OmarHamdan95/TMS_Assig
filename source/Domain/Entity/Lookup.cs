using AjKpi.Domain.Common;
using AjKpi.Domain.MarkarEntity;

namespace AjKpi.Domain;

public class Lookup : LookupBase ,IAggregateRoot
{
    public Lookup(){}

    public Lookup(string? code, string? nameAr, string? nameEn,
        string? dataType , long? parentId)
    {
        Code = code;
        NameAr = nameAr;
        NameEn = nameEn;
        DataType = dataType;
        ParentId = parentId;
        ValidFrom = DateTime.Now;
        IsSystem = true;
        // _lookupValues = lookupValues;
    }

    public void AddLookupValue(LookupValue lookupValue)
    {
        _lookupValues.Add(lookupValue);
    }

    public Lookup(long id) => Id = id;
    public virtual Lookup? Parent { get; set; }
    public long? ParentId { get; set; }
    public long? Links { get; set; }
    public List<LookupValue>? _lookupValues = new List<LookupValue>();
    public virtual IReadOnlyCollection<LookupValue> LookupValues =>
        _lookupValues.AsReadOnly();

    public virtual bool IsSystem { get; set; }
    public virtual string? DataType { get; set; }


    public void UpdateLookup(string? nameAr, string? nameEn, List<LookupValue>? lookupValues, string? dataType,
        Lookup? parent)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        _lookupValues = lookupValues;
        DataType = dataType;
        Parent = parent;
    }

    public void Inactivate() => ValidTo = DateTime.Now.AddDays(-1);
}
