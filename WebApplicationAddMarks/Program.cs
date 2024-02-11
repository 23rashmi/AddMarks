using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationAddMarks.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AddMarksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AddMarksContext") ?? throw new InvalidOperationException("Connection string 'AddMarksContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
