using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Services.Interfaces.IRegions;
using NZWalks.API.Services.Interfaces.Iwalks;
using NZWalks.API.Services.Repositoreis.RegionRepos;
using NZWalks.API.Services.Repositoreis.WalkRepos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "NZWalks.API",
        Description = "Example Web API NZWalks"
    });
});

builder.Services.AddDbContext<NZWalksDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("NZWalkConnectionString")));

builder.Services.AddScoped<IRegionRepositories, RegionRepositories>();
builder.Services.AddScoped<IWalksRepositories, WalksRepositories>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
