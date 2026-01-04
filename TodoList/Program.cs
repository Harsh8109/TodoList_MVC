using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodoDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository as a singleton for Dependency Injection
//builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

// Register the SQL Server implementation as a singleton for Dependency Injection
builder.Services.AddScoped<ITodoRepository, SqlServerTodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
