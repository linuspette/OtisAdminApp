using Newtonsoft.Json;
using OtisAdminApp.Models.InputModels.Errands;
using OtisAdminApp.Models.ViewModels.Errands;

namespace OtisAdminApp.Services;

public interface IErrandDataService
{
    public Task<List<ErrandViewModel>> GetAllElevatorErrands(string deviceId = null!);
    public Task<ErrandViewModel> GetErrand(string errandNumber);
    public Task<ErrandViewModel> PostErrandAsync(ErrandInputModel userInput);
    public Task<bool> PostErrandUpdateAsync(ErrandUpdateInputModel userInput);
    public Task<bool> DeleteErrandAsync(string errandNumber);
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
            errandListJsonObject= await _apiService.GetAsync($"errands/geterrands", null);

        return JsonConvert.DeserializeObject<List<ErrandViewModel>>(errandListJsonObject) ?? null!;
    }

    public async Task<ErrandViewModel> GetErrand(string errandNumber)
    {
        //Dictionary is for the header to be set
        var errandJsonObject = await _apiService.GetAsync("errands/geterrand", new Dictionary<string, string> { { "errandNumber", errandNumber } });

        return JsonConvert.DeserializeObject<ErrandViewModel>(errandJsonObject) ?? null!;
    }

    public async Task<ErrandViewModel> PostErrandAsync(ErrandInputModel userInput)
    {


        var result = await _apiService.PostAsync("errands/createerrand", JsonConvert.SerializeObject(userInput, Formatting.Indented));

        return JsonConvert.DeserializeObject<ErrandViewModel>(result) ?? null!;
    }

    public async Task<bool> PostErrandUpdateAsync(ErrandUpdateInputModel userInput)
    {
        var result = await _apiService.PostAsync("errands/updateerrand", JsonConvert.SerializeObject(userInput));

        if (!string.IsNullOrEmpty(result))
        {
            if (result == "0")
                return true;
        }

        return false;
    }

    public async Task<bool> DeleteErrandAsync(string errandNumber)
    {
        var result = await _apiService.DeleteAsync("errands/deleteerrand",
            new Dictionary<string, string> { { "errandNumber", errandNumber } });

        if (!string.IsNullOrEmpty(result))
        {
            if (result == "0")
                return true;
        }
        return false;
    }
}