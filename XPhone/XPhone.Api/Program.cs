using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPhone.Infrastructure;
using XPhone.Infrastructure.Repository;
using XPhone.Api.Controller;
using XPhone.Infra.Repository;
using System.Text.Json.Serialization;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;
using Microsoft.AspNetCore.WebSockets;

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


builder.Services.AddScoped<ISmartPhoneRepository, SmartPhoneRepository>();


//cqrs

//stock
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddTransient<ICommandHandler<UpdateStockCommmand>, UpdateStockCommmandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteStockCommand>, DeleteStockCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateStockCommand>, CreateStockCommandHandler>();
builder.Services.AddScoped<IStockQueryService, StockQueryService>();

//client
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddTransient<ICommandHandler<UpdateCLientCommand>, UpdateCLientCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteClientCommand>, DeleteClientCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateClientCommand>, CreateClientCommandHandler>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();

//return
builder.Services.AddScoped<IReturnRepository,  ReturnRepository>();
builder.Services.AddTransient<ICommandHandler<UpdateReturnCommand>, UpdateReturnCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteReturnCommand>, DeleteReturnCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateReturnCommand>, CreateReturnCommandHandler>();
builder.Services.AddScoped<IReturnQueryService, ReturnQueryService>();

//rent
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddTransient<ICommandHandler<UpdateRentCommand>, UpdateRentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateRentCommand>, CreateRentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteRentCommand>, DeleteRentCommandHandler>();
//builder.Services.AddTransient<ICommandHandler<CreateSmartPhoneCommand>, CreateSmartPhoneCommandHandler>();
builder.Services.AddScoped<IRentQueryService,  RentQueryService>();

//smartphone
builder.Services.AddScoped<ISmartPhoneRepository, SmartPhoneRepository>();
builder.Services.AddTransient<ICommandHandlerCreate<CreateSmartPhoneCommand>, CreateSmartPhoneCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateSmartPhoneCommand>, UpdateSmartPhoneCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteSmartPhoneCommand>, DeleteSmartPhoneCommandHandler>();
builder.Services.AddScoped<ISmartPhoneQueryService, SmartPhoneQueryService>();


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
