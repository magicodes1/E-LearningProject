using Microsoft.AspNetCore.Identity;
using ElearningApplication.Data;
using Microsoft.EntityFrameworkCore;
using ElearningApplication.Models.Entities;
using ElearningApplication.Extensions;
using ElearningApplication.Models.Error;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ELearningDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ELearningDbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // options.Lockout.MaxFailedAccessAttempts = 5;
    // options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";

    options.User.RequireUniqueEmail = true;
});

// jwt config
builder.Services.AddJwtTokenAuthentication(builder.Configuration);





var app = builder.Build();

app.Logger.LogInformation("Api is creating...................");

// blobal error catching.
app.ConfigureExceptionHandler();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Logger.LogInformation("Launching Application.....");

app.Run();
