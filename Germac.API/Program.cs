using Germac.CrossCutting.ServiceCollectionExtensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Read configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR and scan the assembly where the handlers are located
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register MediatR and scan the assembly where the handlers are located
// Path to the DLL if it is not directly referenced
// Assuming the DLL is in the output directory
string pathToDll = Path.Combine(AppContext.BaseDirectory, "Germac.Application.dll");
Assembly externalAssembly = Assembly.LoadFrom(pathToDll);

// Register MediatR and scan the loaded assembly for request handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(externalAssembly));

var services = new ServiceCollection();

services.AddServices(configuration);
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

