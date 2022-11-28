using Newtonsoft.Json;
using OtisAdminApp.Models.ViewModels.Users;

namespace OtisAdminApp.Models.InputModels.Errands;

public class ErrandUpdateInputModel
{
    [JsonProperty("status")] public string Status { get; set; } = null!;
    [JsonProperty("message")] public string Message { get; set; } = null!;
    [JsonProperty("isResolved")] public bool IsResolved { get; set; }
    [JsonProperty("employees")] public List<EmployeeViewModel>? Employees { get; set; }
}