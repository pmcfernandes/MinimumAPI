using APIBase.Models;

namespace APIBase.Data;

public class LoginData : ILoginData
{

    private readonly ISqlDataAccess db;

    public LoginData(ISqlDataAccess db)
    {
        this.db = db;
    }

    public async Task<UserTokenModel?> Login(LoginModel login)
    {
        var results = await db.Load<UserTokenModel, dynamic>("dbo.xp_Login", new
        {
            login.Username, 
            login.Password
        });

        return results.FirstOrDefault();
    }
}
