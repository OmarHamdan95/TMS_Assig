using AjKpi.Domain.Common;
using AjKpi.Domain.MarkarEntity;

namespace AjKpi.Domain;

public class SystemMenu : BaseAuditableEntity , IAggregateRoot
{
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string? Route { get; set; }
    public string? Permission { get; set; }
    public SystemMenu? Parent { get; set; }
    public long? ParentId { get; set; }
    public List<SystemMenu> Child { get; set; }
    public string? ModuleCode { get; set; }

    public SystemMenu(){}

    public SystemMenu(long id) => Id = id;

    public SystemMenu(string? name, string? icon, string? route, string? permission, SystemMenu? parent,string? ModuleCode,
        List<SystemMenu> child)
    {
        Name = name;
        Icon = icon;
        Route = route;
        Permission = permission;
        Parent = parent;
        Child = child;
    }
}
