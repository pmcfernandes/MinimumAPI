namespace APIBase;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> Load<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

    Task Save<T>(string storedProcedure, T parameters, string connectionId = "Default");

}