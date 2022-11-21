using Newtonsoft.Json;
using OtisAdminApp.Models.ViewModels.Errands;

namespace OtisAdminApp.Services;

public interface IErrandDataService
{
    public Task<List<ErrandViewModel>> GetAllElevatorErrands(string deviceId);
}
public class ErrandDataService : IErrandDataService
{
    private readonly IApiService _apiService;

    public ErrandDataService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<ErrandViewModel>> GetAllElevatorErrands(string deviceId)
    {
        var header = new Dictionary<string, string> { { "id", deviceId } };

        var errandListJsonObject = await _apiService.GetAsync($"elevators/getelevator", header);
        if (errandListJsonObject != null)
            return JsonConvert.DeserializeObject<List<ErrandViewModel>>(errandListJsonObject)!;

        return null!;
    }
}