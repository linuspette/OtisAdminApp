namespace OtisAdminApp.Models.InputModels.Elevator;

public class UpdateElevatorInputModel
{
    public Guid Id { get; set; }
    public string Location { get; set; } = null!;
}