using ContactsControl.Data;
using ContactsControl.Helpers;
using ContactsControl.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Configure the database context
var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<DataBaseContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region Configure Interface and Repository
builder.Services.AddScoped<ContactsControl.Helpers.ISession, Session>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

// Check if the database exists
if (!dbContext.Database.CanConnect())
{
    // Create the database if it doesn't exist
    dbContext.Database.EnsureCreated();
    // Read the SQL script file
    var scriptFilePath = Path.Combine(AppContext.BaseDirectory, "Scripts", "ContactsControl.sql");
    var script = File.ReadAllText(scriptFilePath);

    // Execute the script to create the database
    dbContext.Database.ExecuteSqlRaw(script);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();