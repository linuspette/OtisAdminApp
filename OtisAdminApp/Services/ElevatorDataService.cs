using Newtonsoft.Json;
using OtisAdminApp.Models.ViewModels.Elevator;

namespace OtisAdminApp.Services;

public interface IElevatorDataService
{
    public Task<ElevatorViewModel> GetElevatorAsync(string deviceId);
    public Task<List<ElevatorViewModel>> GetAllElevatorsAsync();
}
public class ElevatorDataService : IElevatorDataService
{
    private readonly IApiService _apiService;

    public ElevatorDataService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<ElevatorViewModel> GetElevatorAsync(string deviceId)
    {
        var header = new Dictionary<string, string>();

        header.Add("id", deviceId);

        var elevatorJsonObject = await _apiService.GetAsync($"elevators/getelevator", header);
        if (elevatorJsonObject != null)
            return JsonConvert.DeserializeObject<ElevatorViewModel>(elevatorJsonObject)!;

        return null!;
    }

    public async Task<List<ElevatorViewModel>> GetAllElevatorsAsync()
    {
        var elevatorJsonObject = await _apiService.GetAsync("elevators/getelevators", null);
        if (elevatorJsonObject != null)
            return JsonConvert.DeserializeObject<List<ElevatorViewModel>>(elevatorJsonObject)!;

        return null!;
    }
}