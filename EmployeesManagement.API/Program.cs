using EmployeesManagement.Application.Services;
using EmployeesManagement.DataAccess;
using EmployeesManagement.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeesDbContext>(
    options =>
    {

        options.UseNpgsql(builder.Configuration.GetConnectionString("EmployeesDb"));
    }
    );
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
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
app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins().AllowAnyOrigin();
    x.WithMethods().AllowAnyMethod();

});

app.Run();