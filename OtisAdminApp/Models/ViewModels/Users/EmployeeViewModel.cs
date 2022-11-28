using OtisAdminApp.Models.ViewModels.Errands;

namespace OtisAdminApp.Models.ViewModels.Users;

public class EmployeeViewModel
{
    public int EmployeeNumber { get; set; }
    public string FullName { get; set; } = null!;
    public List<ErrandViewModel>? ErrandViewModels { get; set; }

    public override bool Equals(object? o)
    {
        var other = o as EmployeeViewModel;
        return other?.FullName == this!.FullName!;
    }
    public override int GetHashCode() => FullName?.GetHashCode() ?? 0;
    public override string ToString() => FullName;
}