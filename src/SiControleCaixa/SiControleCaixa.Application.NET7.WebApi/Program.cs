using Microsoft.EntityFrameworkCore;
using SiControleCaixa.ApplicationCore.IoC;
using SiControleCaixa.Infrastructure.Data.Context;
using SiControleCaixa.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddApplicationIdentity();
builder.Services.AddApplicationJwtAuth(builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>());




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



Startup.RegisterServices(builder.Services);

var connectionString = builder.Configuration.GetConnectionString("SiControleCaixaConnection");

builder.Services.AddDbContext<SiControleCaixaSqlContext>(x => x.UseSqlServer(connectionString));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
