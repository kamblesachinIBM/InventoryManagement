using Microsoft.EntityFrameworkCore;
using Inventory.Application.Handlers;
using Inventory.Core.Repositories;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext: Path: CodePulse.API/Program.cs
//builder.Services.AddDbContext<InventoryDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryMgmtConnectionString"));
//});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost\\MSSQLSERVER01;Database=InventoryManagementDb;Trusted_Connection=true;";
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Mediatr
// Register MediatR (scan the assembly that contains your handlers)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllInventoryHandler>());

// Add Repositories
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

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
