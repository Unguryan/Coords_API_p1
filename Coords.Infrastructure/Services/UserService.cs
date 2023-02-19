using Coords.App.Services;
using Coords.Domain.Models;
using Coords.Domain.Options;
using Coords.Domain.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace Coords.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IOptions<UserServiceOptions> _options;

        public UserService(IOptions<UserServiceOptions> options)
        {
            _options = options;
        }

        public async Task<User> GetUserByToken(string userToken)
        {
            using(var http = new HttpClient())
            {
                var resp = await http.GetAsync(_options.Value.UserServiceUrl + $"/telegram/token/{userToken}");
                resp.EnsureSuccessStatusCode();

                var resp_str = await resp.Content.ReadAsStringAsync();
                //string Token, string Data, DateTime Expired

                var jObj = JConstructor.Parse(resp_str);
                var tokenObj = jObj.SelectToken("$.token").ToString();
                var dataObj = jObj.SelectToken("$.data").ToString();
                var expiredObj = jObj.SelectToken("$.expired").ToString();

                var dataBytes = Convert.FromBase64String(dataObj);
                var dataJson = Encoding.UTF8.GetString(dataBytes);

                var user = JsonSerializer.Deserialize<TokenInfoViewModel>(dataJson);

                if(user == null)
                {
                    return null;
                }

                return new User()
                {
                    ChatId = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber
                };
            }
        }
    }
}
