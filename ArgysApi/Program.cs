using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArgysApi.Data;
using ArgysApi.mappers.Admin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigins", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<ArgysApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArgysApiContext") ?? throw new InvalidOperationException("Connection string 'ArgysApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to mapper
builder.Services.AddScoped<AdministradoraMapper>();

var app = builder.Build();

app.UseCors("AllowAnyOrigins");

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
