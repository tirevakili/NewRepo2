using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

using PayaTejaratDto.Options.API;

using System.Text;
using TakGhahCore.DTOs.UserModel;

namespace TakGhahWeb.Services.Authentication
{
    public class AuthenticationService : Implements.IAuthenticationService
    {
        [Inject] protected HttpClient _httpClient { get; set; } = new();

        public async Task<string> SignIn(LoginViewModel dto)
        {
            var SterilizeOb = JsonConvert.SerializeObject(dto);

            var response = await _httpClient.PostAsync($"{APIs.BaseUrl}{APIs.Authentication}", new StringContent(SterilizeOb, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
            {
                var result = await response?.Content?.ReadFromJsonAsync<TokenModel>()!;
                return result?.Token!;
            }


            return "";



        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Register(RegisterViewModel dto)
        //{
        //    var SterilizeOb = JsonConvert.SerializeObject(dto);

        //    var response = await _httpClient.PostAsync($"{APIs.BaseUrl}{APIs.RegisterUser}", new StringContent(SterilizeOb, Encoding.UTF8, "application/json")) ?? new();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await Task.FromResult(true);
        //    }
        //    return await Task.FromResult(false);

        //}

        public async Task<string> SignInCompony(LoginViewModel dto)
        {
            var SterilizeOb = JsonConvert.SerializeObject(dto);

            var response = await _httpClient.PostAsync($"https://api.karenlastik.com/AuthenticationCompony", new StringContent(SterilizeOb, Encoding.UTF8, "application/json"));

            var result = response.Content.ReadFromJsonAsync<TokenModel>().Result;

            return result?.Token!;
        }

        //public async Task<bool> RegisterCompony(UserViewModel dto)
        //{
        //    var SterilizeOb = JsonConvert.SerializeObject(dto);

        //    var response = await _httpClient.PostAsync($"https://api.karenlastik.com/RegisterCompony", new StringContent(SterilizeOb, Encoding.UTF8, "application/json")) ?? new();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await Task.FromResult(true);
        //    }
        //    return await Task.FromResult(false);
        //}
    }
}
