using System.Reflection;
using ISCC.Api;
using ISCC.Api.Controllers;
using ISCC.Domain.DependencyInjection;
using ISCC.Domain.Models;
using ISCC.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configure = builder.Configuration;

builder.Services.AddAutoMapper(config =>
    config.AddMaps(Assembly.GetAssembly(typeof(ProjectController))));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", configurePolicy =>
    {
        configurePolicy.WithOrigins(configure["Cors:Origins"]!)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddStorage(configure.GetConnectionString("MainDbContext")!);
builder.Services.AddDomain();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
await app.AddSeed();
app.Run();

