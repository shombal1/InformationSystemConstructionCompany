using System.Reflection;
using ISCC.Api.Models.Response;

var builder = WebApplication.CreateBuilder(args);

var configure = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", configurePolicy =>
    {
        configurePolicy.WithOrigins(configure["Cors:Origins"]!)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
});
var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();