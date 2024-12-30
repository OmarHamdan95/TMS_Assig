using TMS.Domain.MarkarEntity;

namespace TMS.Domain;

public class User : BaseAuditableEntity, IAggregateRoot
{
    public User
    (
        string nameAr,
        string nameEn,
        string userName,
        string mobileNumber,
        string email,
        UserRole? role
    )
    {
        NameAr = nameAr;
        NameEn = nameEn;
        UserName = userName;
        Email = email;
        MobileNumber = mobileNumber;
        Role = role;
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

    public UserRole? Role { get; private set; }

    public void UpdateName(string nameAr, string nameEn) => (NameAr, NameEn) = (nameAr, nameEn);

    public void SetUserName(string userName) => UserName = userName;
    public void UpdateEmail(string email) => Email = email;
    public void UpdateMobile(string mobileNumber) => MobileNumber = mobileNumber;
    public void UpdateRole(UserRole? role) => Role = role;

    public void Activate() => Status = Status.Active;

    public void Inactivate() => Status = Status.Inactive;
}
