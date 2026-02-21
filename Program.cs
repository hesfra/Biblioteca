using Biblioteca.Commons.Logging;
using ILogger = Biblioteca.Commons.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Controllers
builder.Services.AddControllers();

// Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<ILogger, ConsoleLogger>();

// Aqui tu registra teus storages
// builder.Services.AddScoped<IUserStorage, InMemoryUserStorage>();
// builder.Services.AddScoped<IUserService, UserService>();

#endregion

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();