using db.Models;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public interface IUserServices
    {
        Task<User> Authenticate(LoginModel userLogin);
        Task CreateUser(UserModel user);
        string Generate(User user);
    }
}