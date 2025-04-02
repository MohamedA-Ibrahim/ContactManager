using ContactManager;
using ContactManager.Data;
using ContactManager.Data.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAppServices();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services
    .AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme)
    .Configure(options => 
    {
        options.BearerTokenExpiration = TimeSpan.FromHours(24);
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options=>
    {
        options
        .WithTheme(ScalarTheme.Default)
        .WithDarkMode(false)
        .WithDarkModeToggle(true)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGroup("api/auth").MapIdentityApi<User>();

app.Run();
