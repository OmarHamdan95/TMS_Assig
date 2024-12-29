using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class SystemMenueSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var menuSet = context.Set<SystemMenu>();

        var menues = new List<SystemMenu>()
        {
            new SystemMenu()
            {
                Name = "Admin",
                Icon = "Admin",
                Code = "Admin",
                ModuleCode = "ADMIN",
                Child = new List<SystemMenu>()
                {
                    new SystemMenu()
                    {
                        Name = "Users",
                        Icon = "Users",
                        Code = "Users",
                        ModuleCode = "ADMIN",
                        Child = new List<SystemMenu>()
                        {
                            new SystemMenu()
                            {
                                Name = "list",
                                Icon = "List",
                                Code = "Users-list",
                                Route = "/admin/users/list",
                                ModuleCode = "ADMIN"
                            }
                        }
                    },

                    new SystemMenu()
                    {
                        Name = "Setup Data",
                        Icon = "SetupData",
                        Code = "Setup-Data",
                        Route = "/admin",
                        ModuleCode = "ADMIN",
                        Child = new List<SystemMenu>()
                        {
                            new SystemMenu()
                            {
                                Name = "Lookups",
                                Icon = "Lookups",
                                Code = "Lookups",
                                Route = "/admin/lookups/list",
                                ModuleCode = "ADMIN"
                            },
                            new SystemMenu()
                            {
                                Name = "Roles",
                                Icon = "Roles",
                                Code = "Roles",
                                Route = "/admin/roles/list",
                                ModuleCode = "ADMIN"
                            },
                            new SystemMenu()
                            {
                                Name = "Departments",
                                Icon = "Departments",
                                Code = "Departments",
                                Route = "/admin/departments/list",
                                ModuleCode = "ADMIN"
                            }
                        }
                    }
                }
            },
            new SystemMenu()
            {
                Name = "Main",
                Icon = "Main",
                Code = "Main",
                ModuleCode = "MAIN",
                Child = new List<SystemMenu>()
                {
                    new SystemMenu()
                    {
                        Name = "Dashboard",
                        Icon = "Dashboard",
                        Code = "Dashboard",
                        Route = "/main/dashboard",
                        ModuleCode = "MAIN"
                    },
                    new SystemMenu()
                    {
                        Name = "Kpi",
                        Icon = "KPI",
                        Code = "Kpi",
                        Route = "/main/kpis/list",
                        ModuleCode = "MAIN",
                        Child = new List<SystemMenu>()
                        {
                            new SystemMenu()
                            {
                                Name = "DraftPerformanceIndicators",
                                Icon = "List",
                                Code = "Draft-Performance-Indicators",
                                Route = "/main/kpis/list",
                                ModuleCode = "MAIN"
                            },
                            new SystemMenu()
                            {
                                Name = "ActiveList",
                                Icon = "ActiveList",
                                Code = "ActiveList",
                                Route = "/main/kpis/active-list",
                                ModuleCode = "MAIN"
                            },
                            new SystemMenu()
                            {
                                Name = "TaskList",
                                Icon = "TaskList",
                                Code = "Kpi-task-list",
                                Route = "/main/kpis/tasks-list",
                                ModuleCode = "MAIN"
                            },
                            new SystemMenu()
                            {
                                Name = "TaskListResult",
                                Icon = "TaskListResult",
                                Code = "TaskListResult",
                                Route = "/main/kpis/task-list-result",
                                ModuleCode = "MAIN"
                            },
                            new SystemMenu()
                            {
                                Name = "Requestlist",
                                Icon = "List",
                                Code = "Requests-list",
                                Route = "/main/requests/list",
                                ModuleCode = "MAIN"
                            },
                        }
                    }
                    // new SystemMenu()
                    // {
                    //     Name = "Requests",
                    //     Icon = "Requests",
                    //     Code = "Requests",
                    //     Route = "/main/requests/list",
                    //     ModuleCode = "MAIN",
                    //     Child = new List<SystemMenu>()
                    //     {
                    //
                    //     }
                    // }
                }
            },
        };


       await UpsertMenusAsync(menues , menuSet , context);
    }

    private async Task UpsertMenusAsync(List<SystemMenu> menus,DbSet<SystemMenu> menuSet , Context _context  = null, SystemMenu parent = null  )
    {
        foreach (var menuData in menus)
        {
            var existingMenu = await menuSet
                .FirstOrDefaultAsync(m => m.Code == menuData.Code);

            if (existingMenu != null)
            {
                // Update existing menu
                existingMenu.Name = menuData.Name;
                existingMenu.Icon = menuData.Icon;
                existingMenu.ModuleCode = menuData.ModuleCode;
                existingMenu.Route = menuData.Route;
                existingMenu.ParentId = parent?.Id;

                menuSet.Update(existingMenu);
            }
            else
            {
                // Create new menu
                var newMenu = new SystemMenu
                {
                    Name = menuData.Name,
                    Icon = menuData.Icon,
                    Code = menuData.Code,
                    ModuleCode = menuData.ModuleCode,
                    Route = menuData.Route,
                    ParentId = parent?.Id
                };

                menuSet.Add(newMenu);
                await _context.SaveChangesAsync(); // Save to get the ID

                if (menuData.Child != null && menuData.Child.Any())
                {
                    await UpsertMenusAsync(menuData.Child.ToList(), menuSet, _context,  newMenu);
                }
            }

            await _context.SaveChangesAsync();

            // If it's an existing menu, handle children after update
            if (existingMenu != null && menuData.Child != null && menuData.Child.Any())
            {
                await UpsertMenusAsync(menuData.Child.ToList(),menuSet, _context, existingMenu);
            }
        }
    }
}
