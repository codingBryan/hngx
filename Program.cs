global using Microsoft.EntityFrameworkCore;
global using AutoMapper;

using backend_stage_one.Models;
using backend_stage_one.Services;
using backend_stage_one;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var conn_string = builder.Configuration.GetConnectionString("exampledb");
builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseMySql(conn_string, ServerVersion.AutoDetect(conn_string));
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IJsonResponseService, JsonResponseService>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
