using System.Reflection;
using ISCC.Api;
using ISCC.Api.Controllers;
using ISCC.Domain.DependencyInjection;
using ISCC.Domain.Models;
using ISCC.Storage;
using ISCC.Storage.DependencyInjection;
using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configure = builder.Configuration;

builder.Services.AddAutoMapper(config =>
    config.AddMaps(Assembly.GetAssembly(typeof(ProjectController))));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", configurePolicy =>
    {
        configurePolicy.AllowAnyOrigin()
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

var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context = services.GetRequiredService<MainDbContext>();

await context.Database.MigrateAsync(); 

var unitTypeId = Guid.Parse("F82901E1-7E54-4FB7-82C7-130D76E9FAA4");
if (await context.UnitTypes.Where(u => u.Id == unitTypeId).CountAsync() == 0)
{
    var unitType = new UnitTypeEntity()
    {
        Id = unitTypeId,
        Name = "шт"
    };
    await context.UnitTypes.AddAsync(unitType);
    await context.SaveChangesAsync();
}
scope.Dispose();

app.Run();


