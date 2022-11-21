namespace OtisAdminApp.Models.InputModels.Errands;

public class ErrandInputModel
{
    public string Title { get; set; } = null!;
    public Guid ElevatorId { get; set; }
    public List<ErrandUpdateInputModel> ErrandUpdates { get; set; } = null!;
    public bool IsResolved { get; set; } = false;
}