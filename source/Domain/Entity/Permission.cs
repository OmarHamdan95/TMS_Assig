using AjKpi.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AjKpi.Domain;

public class Permission : LookupBase
{
    public virtual Role? Role { get; set; }
    public long? RoleId { get; set; }

    public Permission()
    {
    }

    public Permission(long id) => Id = id;

    public Permission(string code, string? nameAr, string? nameEn, long? roleId)
    {
        Code = code;
        NameAr = nameAr;
        NameEn = nameEn;
        RoleId = roleId;
    }

    public void UpdatePermission(string? nameAr, string? nameEn)
    {
        NameAr = nameAr;
        NameEn = nameEn;
    }
}
