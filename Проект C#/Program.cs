using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Some_API.Abstractions;
using Some_API.Data;
using Some_API.Repositories;
using Some_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddDbContext<MerchantDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("MerchantDbContext"));
    });
builder.Services.AddDbContext<EmployeeDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("MerchantDbContext"));
    });

builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();

builder.Services.AddScoped<IMerchantService, MerchantService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        /*c.RoutePrefix = string.Empty; */// Сделайте Swagger доступным по корневому пути
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
