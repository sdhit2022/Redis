using DataBase_Test.SQL;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ISQLContext, SQLContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISqlService,SqlService>();



builder.Services.AddControllers();

var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
var environmentName = builder.Environment.EnvironmentName;

//builder.Configuration
//    .SetBasePath(currentDirectory)
//    .AddJsonFile("appsettings.json", false, true)
//    .AddJsonFile($"appsettings.{environmentName}.json", true, true)
//    .AddEnvironmentVariables();

//// blah blah 
//builder.Services.AddDbContext<SQLContext>(
//    opt => opt.UseSqlServer("name=SQL"));







builder.Services.AddDbContext<SQLContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MySQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
