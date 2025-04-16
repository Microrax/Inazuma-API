using FluentAssertions.Common;
using InazumaAPI.Application;
using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Application.Commands;
using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Application.Querys;
using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Infrastructure;
using InazumaAPI.Infrastructure.DbContexts;
using InazumaAPI.Infrastructure.Repositories;
using InazumaAPI.Infrastructure.Repositories.QueryRepositories;
using InazumaAPI.Infrastructure.Services;
using InazumaAPI.Reads.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlconfg = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mysqlconfg);

builder.Services.AddScoped<PlayerService>();

builder.Services.AddDbContext<InazumaDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<PlayerQueryService>();

builder.Services.AddScoped<IQueryHandler<GetPlayerQuery, PlayerModel>, GetPlayerQueryHandler>();
builder.Services.AddScoped<ICommandHandler<AddPlayerCommand>, AddPlayerCommandHandler>();
builder.Services.AddScoped<IPlayerQueryRepository, PlayerQueryRepository>();

builder.Services.AddScoped<IPlayerModelRepository, PlayerRepository>();


builder.Services.AddCommands();
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
