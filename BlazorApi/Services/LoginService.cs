// Services/LoginService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorApi.Models;


public class LoginService
{
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string apiUrl = "https://api.cubemaster.space:4351/api/Account/GetToken";

    public async Task<string> GetToken(LoginModel loginModel)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(apiUrl, jsonContent);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

       
        return null;
    }
}
