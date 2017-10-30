using Lottery.Application.Abstract;
using Lottery.Application.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Application.Services
{
    public class LoginService : ILoginService
    {
        public async Task<bool> LogIn(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/login";

                var dict = new Dictionary<string, string>
                {
                    {"userName", username },
                    {"password", password }
                };
                var content = new FormUrlEncodedContent(dict);

                var response = await (await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<UserDTO>(response);
                return user.IsLoggedIn;
            }
        }

        public async Task<bool> LogInAsAdmin(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/loginToAdmin";

                var dict = new Dictionary<string, string>
                {
                    {"userName", username },
                    {"password", password }
                };
                var content = new FormUrlEncodedContent(dict);

                var response = await (await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(response);
            }
        }
        public async Task<bool> Register(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/register";

                var dict = new Dictionary<string, string>
                {
                    {"userName", username },
                    {"password", password }
                };
                var content = new FormUrlEncodedContent(dict);

                var response = await (await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(response);
            }
        }
    }
}