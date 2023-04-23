using MinimumAPI.Filters;
using MinimumAPI.Models.Data;

namespace MinimumAPI.Endpoints
{
    public static class ProfileEndpoints
    {
        /// <summary>
        /// Configures the user endpoints.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureProfileEndpoints(this WebApplication app)
        {
            app.MapGet("/profiles", GetProfiles)
                .AddEndpointFilter<ValidateBearerEndpointFilter>();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static async Task<IResult> GetProfiles(IProfileData data)
        {
            try
            {
                var results = await data.GetProfiles();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}