using APIBase.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace APIBase.Data;

public class NavBarData : INavBarData
{
    private readonly IConfiguration configuration;

    public NavBarData(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ModuleModel>> GetNavBar(int idUser, string connectionId = "Default")
    {
        List<ModuleModel> model = new List<ModuleModel>();

        using (IDbConnection conn = new SqlConnection(configuration.GetConnectionString(connectionId)))
        {
            using (SqlMapper.GridReader reader = await conn.QueryMultipleAsync("dbo.xp_GetNavBar", new { IDUser = idUser }, commandType: CommandType.StoredProcedure))
            {
                IEnumerable<ModuleModel> modules = reader.Read<ModuleModel>();
                IEnumerable<ContextModel> contexts = reader.Read<ContextModel>();

                foreach (var module in modules)
                {
                    foreach (var context in contexts.Where(x => x.IDModule == module.IDModule))
                    {
                        module.Contexts.Add(context);
                    }

                    model.Add(module);
                }
            }
        }

        return model;
    }
}
