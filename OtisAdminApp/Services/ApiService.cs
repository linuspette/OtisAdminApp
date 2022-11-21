﻿using Newtonsoft.Json;
using System.Net.Http.Json;

namespace OtisAdminApp.Services;

public interface IApiService
{
    public Task<string> GetAsync(string apiCall, IDictionary<string, string>? header);
    public Task<string> PostAsync(string apiRoute, dynamic data);
}
public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAdress = "https://otisagileapi.azurewebsites.net/api/";

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

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

    public async Task<string> PostAsync(string apiRoute, dynamic data)
    {
        try
        {
            string jsonObject = JsonConvert.SerializeObject(data);

            var result = await _httpClient.PostAsJsonAsync($"{_baseAdress}{apiRoute}", jsonObject);

            return await result.Content.ReadAsStringAsync();
        }
        catch { }
        return null!;
    }
}