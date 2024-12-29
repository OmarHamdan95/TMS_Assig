namespace AjKpi.Domain;


public class Role : LookupBase , IAggregateRoot
{

    public Role
  (
      string nameAr,
      string nameEn,
      long? departmentId,
      string code
  )
    {
        NameAr = nameAr;
        NameEn = nameEn;
        Code = code;
        DepartmentId = departmentId;
    }

    public Role(long id) => Id = id;

    public Role()
    {
    }


    public Department Department { get; private set; }

    public List<Permission?> Permissions { get; set; }

    public long? DepartmentId { get; set; }

    public void UpdateName(string nameAr, string nameEn) => (NameAr, NameEn) = (nameAr, nameEn);



}
