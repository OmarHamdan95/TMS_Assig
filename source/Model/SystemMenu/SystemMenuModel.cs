namespace AjKpi.Model;

public class SystemMenuModel
{
    public string? Name { get; init; }
    public string? Icon { get; init; }
    public string? Route { get; init; }
    public string? Permission { get; init; }
    public SystemMenuModel? Parent { get; init; }
    public List<SystemMenuModel>? Child { get; init; }
    public string? ModuleCode { get; init; }
}
