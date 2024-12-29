using AjKpi.Domain.MarkarEntity;

namespace AjKpi.Domain;

public class User : BaseAuditableEntity, IAggregateRoot
{
    public User
    (
        string nameAr,
        string nameEn,
        string userName,
        string mobileNumber,
        string email,
        long? departmentId,
        long? roleId
    )
    {
        NameAr = nameAr;
        NameEn = nameEn;
        UserName = userName;
        Email = email;
        DepartmentId = departmentId;
        MobileNumber = mobileNumber;
        RoleId = roleId;
        Activate();
    }

    public User(long id) => Id = id;

    public User()
    {
    }


    public string? UserName { get; private set; }
    public string? NameAr { get; private set; }
    public string? NameEn { get; private set; }

    public string? Email { get; private set; }
    public string? MobileNumber { get; private set; }

    public Status Status { get; private set; }

    public Department Department { get; private set; }

    public long? DepartmentId { get; private set; }

    public Role Role { get; private set; }
    public long? RoleId { get; private set; }


    public void UpdateName(string nameAr, string nameEn) => (NameAr, NameEn) = (nameAr, nameEn);

    public void SetUserName(string userName) => UserName = userName;
    public void UpdateEmail(string email) => Email = email;
    public void UpdateMobile(string mobileNumber) => MobileNumber = mobileNumber;
    public void UpdateRole(long? roleId) => RoleId = roleId;
    public void UpdateDepartment(long? departmentId ) => DepartmentId  = departmentId;

    public void Activate() => Status = Status.Active;

    public void Inactivate() => Status = Status.Inactive;
}
