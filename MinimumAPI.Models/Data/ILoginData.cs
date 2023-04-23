using APIBase.Models;

namespace APIBase.Data;

public interface ILoginData
{
    Task<UserTokenModel?> Login(LoginModel login);
}