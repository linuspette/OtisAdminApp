using Newtonsoft.Json;
using OtisAdminApp.Models.ViewModels.Users;

namespace OtisAdminApp.Services;

public interface IEmployeeDataService
{

}
public class EmployeeDataService : IEmployeeDataService
{
    private readonly IApiService _apiService;

    public EmployeeDataService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync()
    {
        var result = await _apiService.GetAsync("employees/getemployees", null);

        if (result != null)
            return JsonConvert.DeserializeObject<List<EmployeeViewModel>>(result)!;

        return null!;
    }
}