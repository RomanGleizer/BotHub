using Application.Mapper;
using AutoMapper;
using BotHub.Server.Extensions;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .Enrich.FromLogContext()
          .WriteTo.Console()
          .WriteTo.File(
             Path.Combine("./", "logs", "diagnostics.txt"),
             rollingInterval: RollingInterval.Day,
             fileSizeLimitBytes: 10 * 1024 * 1024,
             retainedFileCountLimit: 2,
             rollOnFileSizeLimit: true,
             shared: true,
             flushToDiskInterval: TimeSpan.FromSeconds(1))
          .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var mapperProfile = new MapperConfiguration(mapperConfigurationExpression 
    => mapperConfigurationExpression.AddProfile(new MappingProfile()));

var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]?>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSingleton(mapperProfile.CreateMapper());
builder.Services.AddCustomCors(corsOrigins);
builder.Services.AddDbContext<BotHubDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddCustomAuthentication();

builder.Services.AddSwaggerGen(swaggerGenOptions => swaggerGenOptions.EnableAnnotations());

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

builder.Host.UseSerilog();

var app = builder.Build();

app.ConfigureMiddleware(builder.Environment);
app.Run();