using APIBase;
using APIBase.Models;

namespace MinimumAPI.Models.Data;

public class ProfileData : IProfileData
{
    private readonly ISqlDataAccess db;

    public ProfileData(ISqlDataAccess db)
    {
        this.db = db;
    }

    public Task<IEnumerable<ProfileModel>> GetProfiles()
    {
        return db.Load<ProfileModel, dynamic>("dbo.sp_GetProfiles", new { });
    }
}
