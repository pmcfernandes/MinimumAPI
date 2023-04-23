using APIBase.Models;

namespace APIBase.Data;

public interface IUserData
{
    Task<IEnumerable<UsersModel>> GetUsers();

    Task<UserModel?> GetUser(int id);

    Task<InsertedUserModel?> InsertUser(UserModel user);

    Task UpdateUser(UserModel user);

    Task DeleteUser(int id);

    Task UpdatePassword(int id, string password);

    Task<IEnumerable<UserGroupModel>> GetGroupsByUser(int id);

    Task<IEnumerable<ProfileModel>> GetProfilesByUser(int id);
}