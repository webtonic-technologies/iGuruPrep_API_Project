using Config_API.Repositories.Services;
using iGuruPrep;
using iGuruPrep.Repositories.Interfaces;
using iGuruPrep.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBoardRepository, BoardRepository>();
builder.Services.AddTransient<IClassRepository, ClassRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IStatusMessageRepository, StatusMessageRepository>();
builder.Services.AddTransient<IClassCourseRepository, ClassCourseRepository>();
// Add services to the container.

// Add services to the container.
builder.Services.AddDbContext<DbContextClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
