using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ContextDB>(options => options.UseMySql(builder.Configuration["connectionstrings:defaultconnection"], new MySqlServerVersion(new Version(8, 0, 22))));
builder.Services.AddDbContext<ContextDB>(options => options.UseInMemoryDatabase("test"));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IUser, UserRepository>();

var app = builder.Build();
app.UseCors(option => 
option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();