using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPhone.Infrastructure;
using XPhone.Infrastructure.Repository;
//using XPhone.API.Controllers;
using XPhone.Api.Controller;
using XPhone.Infra.Repository;
using System.Text.Json.Serialization;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// add controller
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<XPhoneDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ISmartPhoneRepository, SmartPhoneRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
//cqrs
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddTransient<ICommandHandler<UpdateStockCommmand>, UpdateStockCommmandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteStockCommand>, DeleteStockCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateStockCommand>, CreateStockCommandHandler>();
builder.Services.AddScoped<IStockQueryService, StockQueryService>();


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
