using FluentValidation;
using Germac.Application.Behaviors;
using Germac.Application.Commands.CreateOrderCommand;
using Germac.Domain.Repositories;
using Germac.Domain.UnitOfWork;
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

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();

// Register MediatR and scan the assembly where the handlers are located
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//// Register MediatR and scan the assembly where the handlers are located
//// Path to the DLL if it is not directly referenced
//// Assuming the DLL is in the output directory
//string pathToDll = Path.Combine(AppContext.BaseDirectory, "Germac.Application.dll");
//Assembly externalAssembly = Assembly.LoadFrom(pathToDll);



//// Register MediatR and scan the loaded assembly for request handlers
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(externalAssembly));
// Registro do MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
// Registrar o MediatR e escanear automaticamente por handlers no assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


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

