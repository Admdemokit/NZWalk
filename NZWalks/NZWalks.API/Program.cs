using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Services.Interfaces.Images;
using NZWalks.API.Services.Interfaces.IRegions;
using NZWalks.API.Services.Interfaces.ITokens;
using NZWalks.API.Services.Interfaces.Iwalks;
using NZWalks.API.Services.Repositoreis.ImageRepos;
using NZWalks.API.Services.Repositoreis.RegionRepos;
using NZWalks.API.Services.Repositoreis.TokenRepos;
using NZWalks.API.Services.Repositoreis.WalkRepos;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Injected Serilog
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/NZWalks_logs.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Warning()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "NZWalks.API",
        Description = "Example Web API NZWalks"
    });

    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                },
                Scheme="Oauth2",
                Name=JwtBearerDefaults.AuthenticationScheme,
                In=ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Injected ZNWalkDbContext

builder.Services.AddDbContext<NZWalksDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("NZWalkConnectionString")));

// Injected AuthDbContext
builder.Services.AddDbContext<NZWalkAuthDbContext>(options =>
                 options.UseMySQL(builder.Configuration.GetConnectionString("NZWalkAuthConnectionString")));

builder.Services.AddScoped<IRegionRepositories, RegionRepositories>();
builder.Services.AddScoped<IWalksRepositories, WalksRepositories>();
builder.Services.AddScoped<IMageRepositories, LocalImagesRepository>();

// Injected Token Repositories
builder.Services.AddScoped<ITokenRepositories, TokenRepositories>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Setup Identity To DB
builder.Services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalk")
            .AddEntityFrameworkStores<NZWalkAuthDbContext>()
            .AddDefaultTokenProviders();

// Setting Up For Password Login
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


// Setting JWT Token From AppSetting.Json
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (builder.Configuration["Jwt:Key"]))
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
    // https://localhost:1234/Images
});

app.MapControllers();

app.Run();
