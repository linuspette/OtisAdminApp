using System.Text;

namespace OtisAdminApp.Services;

public interface IApiService
{
    public Task<string> GetAsync(string apiCall, IDictionary<string, string>? header);
    public Task<string> PostAsync(string apiRoute, dynamic data);
    public Task<string> DeleteAsync(string apiCall, IDictionary<string, string> header);
}
public class ApiService : IApiService
{
    private readonly ILogger<ApiService> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _baseAdress = "https://otisagileapi.azurewebsites.net/api/";

    public ApiService(ILogger<ApiService> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }

    //Get Method
    public async Task<string> GetAsync(string apiCall, IDictionary<string, string>? header)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAdress + apiCall);
            if (header != null)
            {
                request.Headers.Add(header.Keys.First(), header.Values.First());
            }


            var result = await _httpClient.SendAsync(request) ?? null!;

            return await result.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            var message = ex.Message;
        }

        return null!;
    }

    //Post Method
    public async Task<string> PostAsync(string apiRoute, dynamic data)
    {
        try
        {
            var request = new StringContent(data, Encoding.UTF8, "application/json");


            var result = await _httpClient.PostAsync(_baseAdress + apiRoute, request);
            _logger.LogWarning($"Result from api: {await result.Content.ReadAsStringAsync()}");
            return await result.Content.ReadAsStringAsync();
        }
        catch { }
        return null!;
    }

    //Delete Method
    public async Task<string> DeleteAsync(string apiCall, IDictionary<string, string> header)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _baseAdress + apiCall);

            foreach (var variable in header)
            {
                request.Headers.Add(variable.Key, header.Values);
            }

            var result = await _httpClient.SendAsync(request);

            return await result.Content.ReadAsStringAsync();
        }
        catch { }
        return null!;
    }
}