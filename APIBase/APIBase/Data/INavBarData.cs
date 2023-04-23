using APIBase.Models;

namespace APIBase.Data
{
    public interface INavBarData
    {
        Task<IEnumerable<ModuleModel>> GetNavBar(int idUser, string connectionId = "Default");
    }
}