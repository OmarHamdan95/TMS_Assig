using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class RoleSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var roleSet = context.Set<Role>();
        var permissionSet = context.Set<Permission>();

        var roles = new List<Role>()
        {
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 1L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 1L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 2L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 2L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 3L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 3L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 4L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 4L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 5L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 5L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 6L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 6L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 7L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            new Role()
            {
                Code = "HeadOfDepartment",
                NameAr = "رئيس القسم",
                NameEn = "Head of Department",
                DepartmentId = 7L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "headOfDepartment",
                        NameEn = "headOfDepartment",
                        NameAr = "headOfDepartment",
                    }
                }
            },
            new Role()
            {
                Code = "DataEntry",
                NameAr = "مدخل البيانات",
                NameEn = "Data Entry",
                DepartmentId = 8L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "CreateKpi",
                        NameEn = "Create Kpi",
                        NameAr = "انشاء مؤشر اداء",
                    },
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    }
                }
            },
            // new Role()
            // {
            //     Code = "HeadOfDepartment",
            //     NameAr = "رئيس القسم",
            //     NameEn = "Head of Department",
            //     DepartmentId = 8L,
            //     Permissions = new List<Permission?>()
            //     {
            //         new Permission()
            //         {
            //             Code = "Update_WorkFlow",
            //             NameEn = "Update WorkFlow",
            //             NameAr = "تحديث سير العمل",
            //         },
            //         new Permission()
            //         {
            //             Code = "headOfDepartment",
            //             NameEn = "headOfDepartment",
            //             NameAr = "headOfDepartment",
            //         }
            //     }
            // },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 1L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 2L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 3L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 4L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 5L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 6L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 7L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 8L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "KPIOwner",
                NameAr = "ملاك المؤشرات",
                NameEn = "KPI Owner",
                DepartmentId = 9L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "kpiOwner",
                        NameEn = "kpiOwner",
                        NameAr = "kpiOwner",
                    }
                }
            },
            new Role()
            {
                Code = "StrategyHeadDepartment",
                NameAr = "رئيس القسم ادارة الاستراتيجية",
                NameEn = "Strategy Head Department",
                DepartmentId = 8L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "stgheadmanager",
                        NameEn = "stgheadmanager",
                        NameAr = "stgheadmanager",
                    }
                }
            },
            new Role()
            {
                Code = "StrategyAuditer",
                NameAr = "مدقق قسم الاستراتيجية",
                NameEn = "strategy Auditer",
                DepartmentId = 8L,
                Permissions = new List<Permission?>()
                {
                    new Permission()
                    {
                        Code = "Update_WorkFlow",
                        NameEn = "Update WorkFlow",
                        NameAr = "تحديث سير العمل",
                    },
                    new Permission()
                    {
                        Code = "StrategyAuditer",
                        NameEn = "StrategyAuditer",
                        NameAr = "StrategyAuditer",
                    }
                }
            },
            new Role()
            {
                Code = "Admin",
                NameAr = "مسؤول النظام",
                NameEn = "Admin",
                DepartmentId = 9L
            },
        };


        foreach (var roleData in roles)
        {
            // Check if role exists
            var existingRole = await roleSet
                .Include(r => r.Permissions)
                .FirstOrDefaultAsync(r => r.Code == roleData.Code && r.DepartmentId == roleData.DepartmentId);

            if (existingRole == null)
            {
                // Insert new role
                await roleSet.AddAsync(roleData);
            }
            else
            {
                // Update existing role
                existingRole.NameAr = roleData.NameAr;
                existingRole.NameEn = roleData.NameEn;

                // Handle permissions
                if (roleData.Permissions != null)
                {
                    // Remove existing permissions
                    if (existingRole.Permissions != null)
                    {
                        permissionSet.RemoveRange(existingRole.Permissions);
                    }

                    // Add new permissions
                    existingRole.Permissions = roleData.Permissions;
                }

                roleSet.Update(existingRole);
            }
        }

        //await context.AddRangeAsync(roles);
        await context.SaveChangesAsync();
    }
}
