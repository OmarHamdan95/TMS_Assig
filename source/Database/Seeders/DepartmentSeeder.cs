using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class DepartmentSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var departmentSet = context.Set<Department>();

        var deparments = new List<Department>()
        {
            new Department()
            {
                Code = "PerformanceSafetyDepartment",
                NameAr = "الحماية المدنية والسلامة",
                NameEn = "Performance of the Civil Protection and Safety"
            },
            new Department()
            {
                Code = "ResourceManagementSupportServices",
                NameAr = "الموارد والخدمات المساندة",
                NameEn = "Resource Management and Support Services"
            },
            new Department()
            {
                Code = "LegalAffairs",
                NameAr = "الشوؤن القانونية",
                NameEn = "Legal Affairs"
            },
            new Department()
            {
                Code = "Centers",
                NameAr = "إدارة المراكز",
                NameEn = "Centers"
            },
            new Department()
            {
                Code = "Operations",
                NameAr = "العمليات",
                NameEn = "Operations"
            },
            new Department()
            {
                Code = "MediaPublicRelations",
                NameAr = "الاعلام والعلاقات العامة",
                NameEn = "Media and Public Relations"
            },
            new Department()
            {
                Code = "OfficeDirectorGeneral",
                NameAr = "مكتب المدير العام",
                NameEn = "Office of the Director General"
            },
            new Department()
            {
                Code = "StrategyDepartment",
                NameAr = "الاستراتيجية وتطوير الاداء",
                NameEn = "Strategy and Performance Development"
            },
            new Department()
            {
                Code = "SystemAdmin",
                NameAr = "مسؤول النظام",
                NameEn = "System Admin"
            },
        };



        foreach (var departmentData in deparments)
        {
            var existingDepartment = await departmentSet
                .FirstOrDefaultAsync(d => d.Code == departmentData.Code);

            if (existingDepartment != null)
            {
                // Update existing department
                existingDepartment.NameAr = departmentData.NameAr;
                existingDepartment.NameEn = departmentData.NameEn;

                departmentSet.Update(existingDepartment);
            }
            else
            {
                // Create new department
                departmentSet.Add(new Department
                {
                    Code = departmentData.Code,
                    NameAr = departmentData.NameAr,
                    NameEn = departmentData.NameEn
                });
            }
        }

        await context.SaveChangesAsync();

    }
}
