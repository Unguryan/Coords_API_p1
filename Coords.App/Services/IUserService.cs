using Coords.Domain.Models;

namespace Coords.App.Services
{
    public interface IUserService
    {
        Task<User> GetUserByToken(string userToken);
    }
}
