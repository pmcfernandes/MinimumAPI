using APIBase.Data;
using APIBase.Models;
using System.Text;

namespace MinimumAPI.Endpoints;

public static class LoginEndpoints
{
    /// <summary>
    /// Configures the login endpoints.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void ConfigureLoginEndpoints(this WebApplication app)
    {
        app.MapPost("/login", Login);
    }

    /// <summary>
    /// Logins the specified user.
    /// </summary>
    /// <param name="login">The login.</param>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    private static async Task<IResult> Login(LoginModel login, ILoginData data)
    {
        try
        {
            var result = await data.Login(login);
            if (result == null) return Results.NotFound();
            
            string str = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{result.Token}|{DateTime.Now.AddHours(1).Ticks}"));
            return Results.Ok(str);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
