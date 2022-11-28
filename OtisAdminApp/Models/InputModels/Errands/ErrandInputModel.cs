using Newtonsoft.Json;

namespace OtisAdminApp.Models.InputModels.Errands;

public class ErrandInputModel
{
    [JsonProperty("title")] public string Title { get; set; } = null!;
    [JsonProperty("elevatorId")] public Guid ElevatorId { get; set; }
    [JsonProperty("errandUpdates")] public List<ErrandUpdateInputModel> ErrandUpdates { get; set; } = null!;
    [JsonProperty("isResolved")] public bool IsResolved { get; set; } = false;
}