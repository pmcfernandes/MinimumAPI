using APIBase.Data;
using APIBase.Models;
using MinimumAPI.Filters;

namespace MinimumAPI.Endpoints;

public static class UserEndpoints
{
    /// <summary>
    /// Configures the user endpoints.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", GetUsers)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapGet("/users/{id}", GetUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapPost("/users", InsertUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapPut("/users", UpdateUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapDelete("/users", DeleteUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapPatch("/users/{id}/updatePassword", UpdateUserPassword)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapGet("/users/{id}/groups", GetGroupsByUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapGet("/users/{id}/profiles", GetProfilesByUser)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();
    }

    /// <summary>
    /// Gets the users.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            var results = await data.GetUsers();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Gets the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Inserts the user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            var results = await data.InsertUser(user);
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

        return Results.Ok();
    }

    /// <summary>
    /// Deletes the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

        return Results.Ok();
    }

    /// <summary>
    /// Updates the user password.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="model">The model.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> UpdateUserPassword(int id, PasswordModel model, IUserData data)
    {
        try
        {
            await data.UpdatePassword(id, model.Password);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

        return Results.Ok();
    }

    /// <summary>
    /// Gets the groups by user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetGroupsByUser(int id, IUserData data)
    {
        try
        {
            var results = await data.GetGroupsByUser(id);
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Gets the profiles by user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetProfilesByUser(int id, IUserData data)
    {
        try
        {
            var results = await data.GetGroupsByUser(id);
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }        
}
