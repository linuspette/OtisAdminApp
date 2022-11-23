using OtisAdminApp.Models.ViewModels.Elevator;
using OtisAdminApp.Models.ViewModels.Users;

namespace OtisAdminApp.Models.ViewModels.Errands;

public class ErrandViewModel
{
    public Guid Id { get; set; }
    public string ErrandNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ElevatorViewModel Elevator { get; set; } = null!;
    public List<ErrandUpdateViewModel> ErrandUpdates { get; set; } = null!;
    public List<EmployeeViewModel> AssignedTechnicians { get; set; } = null!;
    public bool IsResolved { get; set; }
}