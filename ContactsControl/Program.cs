using ContactsControl.Data;
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

#region Configure Interface and Repository
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();