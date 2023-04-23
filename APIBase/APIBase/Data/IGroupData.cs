using APIBase.Models;

namespace APIBase.Data;

public interface IGroupData
{
    Task<GroupModel?> GetGroup(int id);
    
    Task<IEnumerable<GroupsModel>> GetGroups();
    
    Task<InsertedUserModel?> InsertGroup(GroupModel user);
    
    Task UpdateGroup(GroupModel user);

    Task DeleteGroup(int id);
}