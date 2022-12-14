using Newtonsoft.Json;

namespace OtisAdminApp.Models.InputModels.Errands;

public class ErrandInputModel
{
    [JsonProperty("title")] public string Title { get; set; } = null!;
    [JsonProperty("elevatorId")] public Guid ElevatorId { get; set; }
    [JsonProperty("errandUpdates")] public ErrandUpdateCreationModel ErrandUpdates { get; set; } = null!;
    [JsonProperty("isResolved")] public bool IsResolved { get; set; } = false;
}

public class ErrandUpdateCreationModel
{
    [JsonProperty("status")] public string Status { get; set; } = null!;
    [JsonProperty("message")] public string Message { get; set; } = null!;
}