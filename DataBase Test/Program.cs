using DataBase_Test.MySQL;
using DataBase_Test.PostgreSQL;
using DataBase_Test.SQL;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ISQLContext, SQLContext>();
builder.Services.AddTransient<ITestDbContext, TestDbContext>();
builder.Services.AddTransient<IPostgresTestDbContext, PostgresTestDbContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISqlService,SqlService>();
builder.Services.AddScoped<IMySqlService,MySqlService>();



builder.Services.AddControllers();


builder.Services.AddDbContext<SQLContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

//builder.Services.AddDbContext<TestDbContext>(_ =>
//    new MySqlConnection(builder.Configuration.GetConnectionString("MySQL")));
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MySQL")));

builder.Services.AddDbContext<PostgresTestDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PastgeSQL")));

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
