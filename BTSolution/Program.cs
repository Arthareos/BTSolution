//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright � 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.BL.Classes;
using BTSolution.BL.Interfaces;
using BTSolution.DAL.Migrations;
using BTSolution.DAL.Repository.Classes;
using BTSolution.DAL.Repository.Interfaces;
using BTSolution.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DB context
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<BTSolutionDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IAccessTokenRepository, AccessTokenRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAccessTokenLogic, AccessTokenLogic>();
builder.Services.AddTransient<IUserLogic, UserLogic>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AccessTokenService>();
builder.Services.AddScoped<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();