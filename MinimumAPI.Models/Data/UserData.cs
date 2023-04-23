using APIBase.Models;

namespace APIBase.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess db;

    public UserData(ISqlDataAccess db)
    {
        this.db = db;
    }

    public Task<IEnumerable<UsersModel>> GetUsers()
    {
        return db.Load<UsersModel, dynamic>("dbo.xp_GetUsers", new { });
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await db.Load<UserModel, dynamic>("dbo.xp_GetUser", new
        {
            IDUser = id
        });

        return results.FirstOrDefault();
    }

    public async Task<InsertedUserModel?> InsertUser(UserModel user)
    {
        var results = await db.Load<InsertedUserModel, dynamic>("dbo.xp_InsertUser", new
        {
            user.Username,
            user.Fullname,
            user.Address,
            user.City,
            user.ZipCode,
            user.Phone,
            user.Mobile,
            user.Email,
            user.IsAuditable
        });

        return results.FirstOrDefault();
    }

    public Task UpdateUser(UserModel user)
    {
        return db.Save("dbo.xp_UpdateUser", user);
    }

    public Task DeleteUser(int id)
    {
        return db.Save("dbo.xp_DeleteUser", new { IDUser = id });
    }

    public Task UpdatePassword(int id, string password)
    {
        return db.Save("dbo.xp_UpdatePasswordUser", new { IDUser = id, Password = password });
    }

    public async Task<IEnumerable<UserGroupModel>> GetGroupsByUser(int id)
    {
        var results = await db.Load<UserGroupModel, dynamic>("dbo.xp_GetUserGroups", new
        {
            IDUser = id
        });

        return results.Where(x => x.InGroup == true);
    }

    public Task<IEnumerable<ProfileModel>> GetProfilesByUser(int id)
    {
        return db.Load<ProfileModel, dynamic>("dbo.xp_GetUserProfiles", new
        {
            IDUser = id
        });
    }
}

