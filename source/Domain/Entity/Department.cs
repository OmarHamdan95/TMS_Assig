namespace AjKpi.Domain;

public class Department : LookupBase , IAggregateRoot
{
    public Department() { }

    public Department(long id) => Id = id;

    public Department(string? code, string? nameAr, string? nameEn)
    {
        Code = code;
        NameAr = nameAr;
        NameEn = nameEn;
        ValidFrom = DateTime.Now;
    }



    public void UpdateDepartment(string? nameAr, string? nameEn)
    {
        NameAr = nameAr;
        NameEn = nameEn;
    }

    public void Inactivate() => ValidTo = DateTime.Now.AddDays(-1);
}
