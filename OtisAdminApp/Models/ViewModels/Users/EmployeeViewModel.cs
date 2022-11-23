using OtisAdminApp.Models.ViewModels.Errands;

namespace OtisAdminApp.Models.ViewModels.Users;

public class EmployeeViewModel
{
    public int EmployeeNumber { get; set; }
    public string FullName { get; set; } = null!;
    public List<ErrandViewModel>? ErrandViewModels { get; set; }
}