using GrpcServer.Services;
using GrpcServer.Application;
using GrpcServer.Infrastructure;
using GrpcServer.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<IStock, StockRepository>();
builder.Services.AddScoped<UseCaseApplication>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<StockService>();

app.MapGet("/", () => "Communication with gRPC");

app.Run();
