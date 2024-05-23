
using TakGhahCore.DTOs.UserModel;

namespace TakGhahWeb.Services.Implements
{
    public interface IAuthenticationService
    {
        Task<string> SignInCompony(LoginViewModel dto);
        //Task<bool> RegisterCompony(UserViewModel dto);
        Task<string> SignIn(LoginViewModel dto);
        //Task<bool> Register(RegisterViewModel dto);
        Task SignOut();
    }
}
