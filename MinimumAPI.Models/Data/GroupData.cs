using APIBase.Models;

namespace APIBase.Data;

public class GroupData : IGroupData
{
    private readonly ISqlDataAccess db;

    public GroupData(ISqlDataAccess db)
    {
        this.db = db;
    }

    public Task<IEnumerable<GroupsModel>> GetGroups()
    {
        return db.Load<GroupsModel, dynamic>("dbo.xp_GetUsers", new { });
    }

    public async Task<GroupModel?> GetGroup(int id)
    {
        var results = await db.Load<GroupModel, dynamic>("dbo.xp_GetUser", new
        {
            IDUser = id
        });

        return results.FirstOrDefault();
    }

    public async Task<InsertedUserModel?> InsertGroup(GroupModel user)
    {
        var results = await db.Load<InsertedUserModel, dynamic>("dbo.xp_InsertUser", new
        {
            user.Username,
            user.Fullname,
            user.Email,
        });

        return results.FirstOrDefault();
    }

    public Task UpdateGroup(GroupModel user)
    {
        return db.Save("dbo.xp_UpdateUser", user);
    }

    public Task DeleteGroup(int id)
    {
        return db.Save("dbo.xp_DeleteUser", new { IDUser = id });
    }
}
