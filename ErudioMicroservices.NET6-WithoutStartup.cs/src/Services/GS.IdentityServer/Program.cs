using GS.IdentityServer.Configuration;
using GS.IdentityServer.Initializer;
using GS.IdentityServer.Model;
using GS.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25))));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MySqlContext>()
    .AddDefaultTokenProviders();

var builderIdentity = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builderIdentity.AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();
var scope = app.Services.CreateScope();

var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();


dbInitializer.Initialize();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();