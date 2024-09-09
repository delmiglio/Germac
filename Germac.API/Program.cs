using Germac.Application.Behaviors;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Logging;
using Germac.Infrastructure.Repositories;
using Germac.Infrastructure.UnitOfWork;
using MediatR;
using MySql.Data.MySqlClient;
using Serilog;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Read configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .MinimumLevel.Debug() // Log debug messages and higher
    .Enrich.FromLogContext()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();

// Registro do ILogger da Serilog
builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IDbConnection>(sp =>
    new MySqlConnection(configuration.GetConnectionString("Default")));

// Add Transient Services
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

// Add Scoped
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(), 
    Assembly.Load("Germac.Application") 
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

