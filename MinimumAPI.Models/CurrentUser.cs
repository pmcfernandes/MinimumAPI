using APIBase.Models;

namespace APIBase;

public class CurrentUser : ICurrentUser
{
    private readonly ISqlDataAccess db;

    public CurrentUser(ISqlDataAccess db)
    {
        this.db = db;
    }

    public string Token
    {
        get;
        set;
    } = "";

    public int GetUser(string token, out string Username)
    {
        Username = "";

        var results = db.Load<UserModel, dynamic>("dbo.xp_GetUserByToken", new
        {
            Token = token
        }).Result;

        var data = results.FirstOrDefault();

        if (data != null)
        {
            Username = data.Username ?? "";
            return data.IDUser;
        }

        return 0;
    }
}
