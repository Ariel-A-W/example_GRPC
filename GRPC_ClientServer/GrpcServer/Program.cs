using GrpcServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PedidoService>();

app.MapGet("/", () => "Comunicaci�n v�a gPRC");

app.Run();
