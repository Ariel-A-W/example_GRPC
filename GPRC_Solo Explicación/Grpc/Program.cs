using Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PedidoService>();

app.MapGet("/", () => "Comunicación vía Cliente-Servidor gRPC: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
