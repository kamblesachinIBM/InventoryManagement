using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Handlers;
using Warehouse.Core.Repositories;
using Warehouse.Infrastructure.Data;
using Warehouse.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext: Path: CodePulse.API/Program.cs
builder.Services.AddDbContext<WarehouseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryMgmtConnectionString"));
});

// Register Mediatr
//var assemblies = new Assembly[]
//{
//    Assembly.GetExecutingAssembly(),
//    typeof(GetAllWarehouseHandler).Assembly
//};
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
// Register MediatR (scan the assembly that contains your handlers)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllWarehouseHandler>());

// Add Repositories
builder.Services.AddScoped<IWareHouseRepository, WarehouseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
