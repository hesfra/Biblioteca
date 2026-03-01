using Biblioteca.Commons.Logging;
using ILogger = Biblioteca.Commons.Logging.ILogger;
using Biblioteca.Interfaces;
using Biblioteca.Services;
using Biblioteca.Storages.InMemory;
using Biblioteca.Storages.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Controllers
builder.Services.AddControllers();

// Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<ILogger, ConsoleLogger>();

// Singleton Userstorage InMemory
 builder.Services.AddSingleton<IUserStorage, UserStorage>();

// repositories

 //services
 builder.Services.AddScoped<IUserService, UserService>();

#endregion

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();