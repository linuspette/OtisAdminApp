using Newtonsoft.Json;
using OtisAdminApp.Models.ViewModels.Errands;

namespace OtisAdminApp.Services;

public interface IErrandDataService
{
    public Task<List<ErrandViewModel>> GetAllElevatorErrands(string deviceId = null!);
    public Task<ErrandViewModel> GetErrand(string errandNumber);
}
public class ErrandDataService : IErrandDataService
{
    private readonly IApiService _apiService;

    public ErrandDataService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<ErrandViewModel>> GetAllElevatorErrands(string deviceId = null!)
    {
        var errandListJsonObject = "";
        //Dictionary is for the header to be set
        if (!string.IsNullOrEmpty(deviceId))
            errandListJsonObject = await _apiService.GetAsync($"elevators/getelevator", new Dictionary<string, string> { { "id", deviceId } });
        else
            errandListJsonObject= await _apiService.GetAsync($"elevators/geterrands", null);

        return JsonConvert.DeserializeObject<List<ErrandViewModel>>(errandListJsonObject) ?? null!;
    }

    public async Task<ErrandViewModel> GetErrand(string errandNumber)
    {
        //Dictionary is for the header to be set
        var errandJsonObject = await _apiService.GetAsync("errands/geterrand", new Dictionary<string, string> { { "errandNumber", errandNumber } });

        return JsonConvert.DeserializeObject<ErrandViewModel>(errandJsonObject) ?? null!;
    }
}