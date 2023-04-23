using APIBase;

namespace MinimumAPI.Filters;

public class ValidateBearerEndpointFilter : IEndpointFilter
{
    private readonly ICurrentUser currentUser;

    public ValidateBearerEndpointFilter(ICurrentUser currentUser)
    {
        this.currentUser = currentUser;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var headerAuth = context.HttpContext.Request.Headers.Where(header => header.Key == "Authorization");

        if (headerAuth.Any() == true)
        {
            string token = headerAuth.First().Value.ToString().Replace("Bearer", "").Trim();

            if (!String.IsNullOrEmpty(token))
            {
                string str = "";

                try
                {
                    str = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(token));
                }
                catch (Exception ex)
                {
                    return Results.Unauthorized();
                }
                
                string[] parts = str.Split('|');

                DateTime dt = new DateTime(Convert.ToInt64(parts[1]));

                if (dt >= DateTime.Now)
                {
                    try
                    {
                        this.currentUser.Token = parts[0];
                        return await next(context);
                    }
                    catch
                    {
                    }
                }
            }
        }

        return Results.Unauthorized();
    }
}