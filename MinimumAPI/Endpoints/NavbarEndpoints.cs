using APIBase;
using APIBase.Data;
using MinimumAPI.Filters;

namespace MinimumAPI.Endpoints;

public static class NavbarEndpoints
{
    /// <summary>
    /// Configures the nav bar endpoints.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void ConfigureNavBarEndpoints(this WebApplication app)
    {
        app.MapGet("/navBar", GetNavBar)
             .AddEndpointFilter<ValidateBearerEndpointFilter>();
    }

    /// <summary>
    /// Gets the navbar.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="currentUser">The current user.</param>
    /// <returns></returns>
    private static async Task<IResult> GetNavBar(INavBarData data, ICurrentUser currentUser)
    {
        int intIdUser = 0;

        if ((intIdUser = currentUser.GetUser(currentUser.Token, out string Username)) > 0)
        {
            try
            {
                var results = await data.GetNavBar(intIdUser);
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        return Results.Unauthorized();
    }
}
