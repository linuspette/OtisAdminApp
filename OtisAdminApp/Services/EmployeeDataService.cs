using Newtonsoft.Json;
using OtisAdminApp.Models.InputModels.Users;
using OtisAdminApp.Models.ViewModels.Users;

namespace OtisAdminApp.Services;

public interface IEmployeeDataService
{
    public Task<List<EmployeeViewModel>> GetAllEmployeesAsync();
    public Task<bool> SaveEmployeeAsync(EmployeeInputModel userInput);
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

        return JsonConvert.DeserializeObject<List<EmployeeViewModel>>(result) ?? null!;
    }

    public async Task<bool> SaveEmployeeAsync(EmployeeInputModel userInput)
    {
        var result = await _apiService.PostAsync("Employees/add", new EmployeePost
        {
            EmployeeNumber = userInput.EmployeeNumber,
            FullName = $"{userInput.FirstName} {userInput.LastName}"
        });

        if (result == "0")
            return true;

        return false;
    }

    private class EmployeePost
    {
        public int EmployeeNumber { get; set; }
        public string FullName { get; set; } = null!;
    }
}