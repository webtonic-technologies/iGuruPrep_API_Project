using Config_API.Repositories.Interfaces;
using Config_API.Repositories.Services;
using iGuruPrep;
using iGuruPrep.Repositories.Interfaces;
using iGuruPrep.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBoardService, BoardService>();
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IStatusMessageService, StatusMessageService>();
builder.Services.AddTransient<IClassCourseService, ClassCourseService>();
builder.Services.AddTransient<IQuestionLevelService, QuestionLevelService>();
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
