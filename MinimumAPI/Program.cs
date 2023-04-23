using APIBase;
using APIBase.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using MinimumAPI.Endpoints;
using MinimumAPI.Filters;
using MinimumAPI.Models.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "http",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ILoginData, LoginData>();
builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.AddSingleton<IGroupData, GroupData>();
builder.Services.AddSingleton<IProfileData, ProfileData>();
builder.Services.AddSingleton<INavBarData, NavBarData>();

builder.Services.Configure<JsonOptions>(
    options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureLoginEndpoints();
app.ConfigureUserEndpoints();
app.ConfigureGroupEndpoints();
app.ConfigureProfileEndpoints();
app.ConfigureNavBarEndpoints();
app.Run();