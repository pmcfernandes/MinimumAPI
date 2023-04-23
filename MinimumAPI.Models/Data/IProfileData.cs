using APIBase.Models;

namespace MinimumAPI.Models.Data;

public interface IProfileData
{
    Task<IEnumerable<ProfileModel>> GetProfiles();
}
