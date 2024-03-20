using ControlPanel_API.DBContext;
using ControlPanel_API.Repositories.Interfaces;
using ControlPanel_API.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnections")!;
builder.Services.AddDbContext<AppDbContext>(c => c.UseSqlServer(connectionString));

builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IMagazineService, MagazineService>();
builder.Services.AddScoped<IStoryOfTheDayService, StoryOfTheDayService>();
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
