using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class PermissionSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var permissionSet = context.Set<Permission>();

        var permissions = new List<Permission>()
        {
            new Permission()
            {
                Code = "Admin",
                NameEn = "Admin",
                NameAr = "مسؤول النطام",
                RoleId = 27L
            }
        };

        foreach (var permission in permissions)
        {
            var existingPermission = await permissionSet
                .FirstOrDefaultAsync(l => l.Code == permission.Code);

            if (existingPermission != null)
            {
                existingPermission.Code = permission.Code;
                existingPermission.NameEn = permission.NameEn;
                existingPermission.NameAr = permission.NameAr;
                existingPermission.RoleId = permission.RoleId;

                permissionSet.Update(existingPermission);
            }
            else
                permissionSet.Add(permission);
        }

        await context.SaveChangesAsync();
    }
}
