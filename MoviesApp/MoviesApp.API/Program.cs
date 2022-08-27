//Microsoft.EntityFrameworkCore.Design
//Microsoft.AspNetCore.Authentication.JwtBearer

using MoviesApp.Configuration;
using System.Text;
using Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure AppSettings class
var appConfig = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appConfig);

// using AppSettings class
var appSettings = appConfig.Get<AppSettings>();


builder.Services.RegisterModule(appSettings.ConnectionString);

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
