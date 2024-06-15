using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPhone.Infrastructure;
using XPhone.Infrastructure.Repository;
//using XPhone.API.Controllers;
using XPhone.Api.Controller;
using XPhone.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// add controller
builder.Services.AddControllers();


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<XPhoneDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();


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
