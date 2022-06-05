using Microsoft.AspNetCore.Identity;
using ElearningApplication.Data;
using Microsoft.EntityFrameworkCore;
using ElearningApplication.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ELearningDbContext>(options=>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
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
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

var app = builder.Build();


app.Run();
