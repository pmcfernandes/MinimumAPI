using APIBase.Data;
using APIBase.Models;
using MinimumAPI.Filters;

namespace MinimumAPI.Endpoints;

public static class GroupEndpoints
{
    /// <summary>
    /// Configures the group endpoints.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void ConfigureGroupEndpoints(this WebApplication app)
    {
        app.MapGet("/groups", GetGroups)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapGet("/groups/{id}", GetGroup)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapPost("/groups", InsertGroup)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapPut("/groups", UpdateGroup)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();

        app.MapDelete("/groups", DeleteGroup)
            .AddEndpointFilter<ValidateBearerEndpointFilter>();
    }

    /// <summary>
    /// Gets the groups.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetGroups(IGroupData data)
    {
        try
        {
            var results = await data.GetGroups();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Gets the group.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> GetGroup(int id, IGroupData data)
    {
        try
        {
            var results = await data.GetGroup(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Inserts the group.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> InsertGroup(GroupModel group, IGroupData data)
    {
        try
        {
            var results = await data.InsertGroup(group);
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Updates the group.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> UpdateGroup(GroupModel group, IGroupData data)
    {
        try
        {
            await data.UpdateGroup(group);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

        return Results.Ok();
    }

    /// <summary>
    /// Deletes the group.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> DeleteGroup(int id, IGroupData data)
    {
        try
        {
            await data.DeleteGroup(id);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

        return Results.Ok();
    }
}
