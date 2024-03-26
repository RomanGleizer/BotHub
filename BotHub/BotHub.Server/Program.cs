using Application.Mapper;
using AutoMapper;
using BotHub.Server.Extensions;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var mapperProfile = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]?>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddCustomAuthentication();

builder.Services.AddSingleton(mapperProfile.CreateMapper());
builder.Services.AddCustomCors(corsOrigins);

builder.Services.AddSwaggerGen(c => c.EnableAnnotations());
builder.Services.AddLogging(c => c.AddConsole());

builder.Services.AddDbContext<BotHubDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.ConfigureMiddleware(builder.Environment);
app.Run();